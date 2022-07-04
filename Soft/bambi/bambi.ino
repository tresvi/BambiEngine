#include <NewPing.h>

#define VELOCIDAD_MAXIMA 250            //Aplica a modo Manual
#define VELOCIDAD_MINIMA 125            //Aplica a modo Manual
#define BAUDRATE 19200                  //Velocidad del puerto serie Bluetooth

//Parametros para la deambulacion
#define VELOCIDAD_DEAMBULACION  250     //Velocidad del vehiculo.
#define DISTANCIA_MIN_PARA_GIRAR  35    //Distancia minima al obstaculo para girar.
#define CICLOS_DE_CONTROL_DESPIERTO 20 //Duración de la accion al despertarse

enum Modo_t {AUTOMATICO, MANUAL, ANALIZADOR, REC_NOTAS};
Modo_t g_modo;
byte g_velocidad = 0;
byte g_contador_control = 0;
bool g_durmiendo = true;

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
  
  //Si no está en ninguno de estos modos, no hago nada, ya que está en modo manual.
  if (g_modo == AUTOMATICO) {
    //!!!!!Parche para continuo!!
    //g_durmiendo = false; g_contador_control = 0;
    if (g_durmiendo){
      if (EscucharNotas() != 0){
        g_durmiendo = false;
        g_contador_control = 0;
      }
    } 
    else {
      if (g_contador_control <= CICLOS_DE_CONTROL_DESPIERTO){
        g_contador_control++;
        ControlDeambulacion();
      }
      else {
        InicializarMotores();
        Serial.println(F("A dormir..."));
        g_durmiendo = true;
      }
    }
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
