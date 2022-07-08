#include <NewPing.h>

#define VELOCIDAD_MAXIMA 250            //Aplica a modo Manual
#define VELOCIDAD_MINIMA 125            //Aplica a modo Manual
#define BAUDRATE 19200                  //Velocidad del puerto serie Bluetooth

//Parametros para la deambulacion
#define VELOCIDAD_DEAMBULACION  250     //Velocidad del vehiculo.
#define DISTANCIA_MIN_PARA_GIRAR  35    //Distancia minima al obstaculo para girar.
#define CICLOS_DE_CONTROL_DESPIERTO 20 //Duración de la accion al despertarse

  long g_ultima_nota = 0;
  #define TIEMPO_DEAMBULACION_MS  3000     //Velocidad del vehiculo.

enum Modo_t {AUTOMATICO, MANUAL, ANALIZADOR, REC_NOTAS};
Modo_t g_modo;
byte g_velocidad = 0;

void setup(){
  InicializarMotores();
  InicializarSonares();
  InicializarMicrofono();
  Serial.begin(BAUDRATE);   //Inicializo puuerto serie
  Serial.println(F("Iniciando Bambi..."));
  g_modo = AUTOMATICO;
}
  
void loop(){
  LeerPuertoSerie();

  if (millis() < TIEMPO_DEAMBULACION_MS) return;   //Para que no arranque pataleando

  //Si no está en ninguno de estos modos, no hago nada, ya que está en modo manual.
  if (g_modo == AUTOMATICO) {  
    if (EscucharNotas() != 0) g_ultima_nota = millis();
    
    if (millis() - g_ultima_nota < TIEMPO_DEAMBULACION_MS )
      ControlDeambulacion();  
    else
      InicializarMotores();  
  }
  else if (g_modo == ANALIZADOR) EjecutarFFT();
  else if (g_modo == REC_NOTAS) EscucharNotas();
}


void LeerPuertoSerie(){ 
  while (Serial.available() > 0) {
    int incomingByte = Serial.read();   //Leo un caracter del buffer del puerto.
    ManejadorDeComandos(incomingByte);  //verifico si corresponde a un comando conocido y lo ejecuto.
  }
}
