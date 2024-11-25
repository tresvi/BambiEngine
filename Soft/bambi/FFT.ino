#define LOG_OUT 1 // use the log output function
#define FHT_N 256 // set to 256 point fht
#define DELAY_ANCHO_BANDA 75  //74 para B.W=6400Hz y Res=50Hz.   75 para simulacion Proteus

//Constantes de Filtros
#define FILTRO_REPETICION_NOTAS 2         //Para desactivar, asignar 1
#define FILTRO_REPETICION_RESET 6         //Al alcanzar este valor de repeticion de NOTAS_INDEFINIDAS, el contador de notas se resetea (cuanto mas alto, mas permisivo). Para desactivar asignar 255 como max.
#define CONDICION_MAXIMO_FUNDAMENTAL 17   //Para desactivar, asignar 1
#define CONDICION_MAXIMO_SOBRETONO 11     //Para desactivar, asignar 1

#include <FHT.h> // include the library

enum Id_Nota_t{NOTA_INDEFINIDA = 0, C2, D2, E2, F2, G3 };
//Global variables use 967 bytes (47%) of dynamic memory, leaving 1.081 bytes for local variables. Maximum is 2.048 bytes.

struct Nota_t{
    Id_Nota_t Id;
    uint8_t F0;
    uint8_t F1;
    uint8_t UMBRAL_F0;    //Umbral Filtro para la fundamental.
    uint8_t UMBRAL_F1;    //Umbral Filtro para el 1er sobretono.
    uint8_t DURACION;
};

//Ingreso Frecuencia Fundamental / Resolucion
#define CANTIDAD_NOTAS 5
Nota_t mNotas[CANTIDAD_NOTAS] = {
   {C2, 2050/50, 5550/50, 93, 79, 3},
   {D2, 2300/50, 6200/50, 75, 45, 2},
   {E2, 2600/50, 5800/50, 75, 45, 2},
   {F2, 2750/50, 5450/50, 55, 10, 2},    //5450 ex 3200
   {G3, 3100/50, 3550/50, 85, 60, 3}
};


void InicializarMicrofono(){
  ADCSRA = 0xe5; // set the adc to free running mode
  ADMUX = 0x45; // use adc5
  DIDR0 = 0x01; // turn off the digital input for adc0
}


//Retorna la nota que reconoció. Devuelve 0 si no reconoció ninguna.
uint8_t EscucharNotas(){
  EjecutarFFT();
  uint8_t nota_escuchada = BuscarNotas();
  
  switch(nota_escuchada){
    case C2: Serial.println("#C2"); break;
    case D2: Serial.println("#D2"); break;
    case E2: Serial.println("#E2"); break;
    case F2: Serial.println("#F2"); break;
    case G3: Serial.println("#G3"); break;
  }
  if (nota_escuchada == NOTA_INDEFINIDA) 
    return 0;
  else 
    return nota_escuchada;
}


void EjecutarFFT() {
  TIMSK0 = 0; // turn off timer0 for lower jitter
  cli();  // UDRE interrupt slows this way down on arduino1.0
  for (int i = 0 ; i < FHT_N ; i++) { // save 256 samples
    while(!(ADCSRA & 0x10)); // wait for adc to be ready
    ADCSRA = 0xf5; // restart adc
    byte m = ADCL; // fetch adc data
    byte j = ADCH;
    int k = (j << 8) | m; // form into an int
    k -= 0x0200; // form into a signed int
    k <<= 6; // form into a 16b signed int
    fht_input[i] = k; // put real data into bins
    delayMicroseconds(DELAY_ANCHO_BANDA);      //
  }

  fht_window(); // window the data for better frequency response
  fht_reorder(); // reorder the data before doing the fht
  fht_run(); // process the data in the fht
  fht_mag_log(); // take the output of the fht
  sei();
  if (g_modo == ANALIZADOR){
    Serial.write(255);                    //Envio el header de la trama
    Serial.write(fht_log_out, FHT_N/2);   // Send out the data.
  }
  TIMSK0 = 1; // Activo nuevamente el Timer0
}


Id_Nota_t mIdNotaAnterior = NOTA_INDEFINIDA;
uint8_t mRepeticionesNotas = 1;
uint8_t mRepeticionesNotaIndefinida = 1;

uint8_t BuscarNotas() {  
  Id_Nota_t nota_encontrada = NOTA_INDEFINIDA;
  uint8_t intensidad_nota = 0;
  uint8_t intensidad_max = 0;
  uint8_t filtro_repeticion_notas = 100;

  for (int i=0; i<CANTIDAD_NOTAS; i++)
  {
      if (FrecuenciaEsMaximo(mNotas[i].F0, mNotas[i].UMBRAL_F0) &&
          FrecuenciaEsMaximo(mNotas[i].F1, mNotas[i].UMBRAL_F1))
      {
        switch(mNotas[i].Id){
          case C2: Serial.println("C2"); break;
          case D2: Serial.println("D2"); break;
          case E2: Serial.println("E2"); break;
          case F2: Serial.println("F2"); break;
          case G3: Serial.println("G3"); break;
        }
        intensidad_nota = fht_log_out[mNotas[i].F0]/2 + fht_log_out[mNotas[i].F1]/4;  //GetIntensidadNota(&mNotas[i]);
        if ( intensidad_nota > intensidad_max ){
          intensidad_max = intensidad_nota;       //Me quedo con la nota de mayor intensidad.
          nota_encontrada = mNotas[i].Id;         //
          filtro_repeticion_notas = mNotas[i].DURACION;
        }
      }
  }

  if (nota_encontrada == NOTA_INDEFINIDA){
    mRepeticionesNotaIndefinida++;
    if (mRepeticionesNotaIndefinida == FILTRO_REPETICION_RESET){
      mRepeticionesNotas = 0;           //Reseteo el contador de notas encontradas
      mRepeticionesNotaIndefinida = 0;  //Reseteo el contador de Indefinidas
    }
  }
  else{
    mRepeticionesNotaIndefinida = 0;  //Reseteo el contador de notas indefinidas
    if (nota_encontrada == mIdNotaAnterior)
      mRepeticionesNotas++;           //Se repitio la nota anterior
    else
      mRepeticionesNotas = 1;         //Reseteo el contador de repeticiones
    mIdNotaAnterior = nota_encontrada;
  }

  //Si se repitio el nro suficiente de veces, la doy como buena.
  if (mRepeticionesNotas == filtro_repeticion_notas){
    mRepeticionesNotas = 0;
    return nota_encontrada;
  }
  else
    return NOTA_INDEFINIDA;     //Si no, no la reconozco.
}


bool FrecuenciaEsMaximo(uint8_t frecuencia, uint8_t umbralDeteccion) {
  uint8_t valor_actual    = fht_log_out[frecuencia];
  uint8_t valor_anterior  = fht_log_out[frecuencia-1];
  uint8_t valor_posterior = fht_log_out[frecuencia+1];  
  uint8_t valor_ante_anterior = fht_log_out[frecuencia-2];
  uint8_t valor_pos_posterior = fht_log_out[frecuencia+2];
  boolean es_maximo = false;
  
  if (valor_actual < umbralDeteccion) return false;

  //Primera condición de Maximo.
  if ((valor_actual > valor_anterior) && (valor_actual > valor_posterior)){
    if ( valor_actual >= valor_ante_anterior + CONDICION_MAXIMO_FUNDAMENTAL &&
         valor_actual >= valor_pos_posterior + CONDICION_MAXIMO_FUNDAMENTAL){
      es_maximo = true;        
    }
  }

  //2da condición de maximos. Contempla las "puntas cuadradas" que no son captadas por la otra condicion
  if (valor_actual == valor_anterior && valor_actual > valor_posterior) 
    es_maximo = true;  

  //3ra condición de maximos. Contempla las "puntas cuadradas" que no son captadas por la otra condicion
  if (valor_actual == valor_posterior && valor_actual > valor_anterior) 
    es_maximo = true; 

  return es_maximo;    
}
