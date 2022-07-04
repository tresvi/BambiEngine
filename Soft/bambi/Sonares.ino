//Defino los alias de los pines del sensor ultrasonico.
#define DIST_MAXIMA 500
#define TRIG_DIST_MED A2
#define ECHO_DIST_MED A1
#define TRIG_DIST_IZQ 4
#define ECHO_DIST_IZQ 3
#define TRIG_DIST_DER A4
#define ECHO_DIST_DER 6

NewPing sonar_Derecho(TRIG_DIST_DER, ECHO_DIST_DER, DIST_MAXIMA);
NewPing sonar_Medio(TRIG_DIST_MED, ECHO_DIST_MED, DIST_MAXIMA);
NewPing sonar_Izquierdo(TRIG_DIST_IZQ, ECHO_DIST_IZQ, DIST_MAXIMA);

void InicializarSonares(){
  //Inicializo los pines del sensor de distancia
//  pinMode(TRIG_DIST_IZQ, OUTPUT);
//  pinMode(ECHO_DIST_IZQ, INPUT);
//  pinMode(TRIG_DIST_MED, OUTPUT);
//  pinMode(ECHO_DIST_MED, INPUT);
//  pinMode(TRIG_DIST_DER, OUTPUT);
//  pinMode(ECHO_DIST_DER, INPUT);
}

unsigned long echoTime;
unsigned long distanciaSonar;

unsigned long LeerSonarIzquierdo(){
  distanciaSonar = sonar_Izquierdo.ping_cm();
  if (distanciaSonar == 0) distanciaSonar = DIST_MAXIMA;
  return distanciaSonar;
}

unsigned long LeerSonarMedio(){
  echoTime = sonar_Medio.ping_median(2); //sonar_Medio.ping_cm();
  distanciaSonar = sonar_Medio.convert_cm(echoTime);
  if (distanciaSonar == 0) distanciaSonar = DIST_MAXIMA;
  return distanciaSonar;
}

unsigned long LeerSonarDerecho(){
  distanciaSonar = sonar_Derecho.ping_cm();
  if (distanciaSonar == 0) distanciaSonar = DIST_MAXIMA;
  return distanciaSonar;
}
