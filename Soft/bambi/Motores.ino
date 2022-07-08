//Defino los alias de los pines del puente H
#define PIN_REVERSA_LEFT  13
#define PIN_REVERSA_RIGHT 12
#define PIN_PWMOUT_LEFT   11
#define PIN_PWMOUT_RIGHT  10
#define PIN_ENABLE_LEFT   9
#define PIN_ENABLE_RIGHT  8

byte g_velocidad = 0;

void MarchaAdelante(){
  digitalWrite(PIN_REVERSA_LEFT, false);
  digitalWrite(PIN_REVERSA_RIGHT, false);
  SetVelocidad(GetVelocidad());
}

void MarchaAtras(){
  digitalWrite(PIN_REVERSA_LEFT, true);
  digitalWrite(PIN_REVERSA_RIGHT, true);
  SetVelocidad(GetVelocidad());
}

void GirarALaIzquierda(){
  digitalWrite(PIN_REVERSA_LEFT, true);
  digitalWrite(PIN_REVERSA_RIGHT, false);
  SetVelocidad(GetVelocidad());
}

void GirarALaDerecha(){
  digitalWrite(PIN_REVERSA_LEFT, false);
  digitalWrite(PIN_REVERSA_RIGHT, true);
  SetVelocidad(GetVelocidad());
}

void Detener(){
  SetVelocidad(0);
  HabilitacionDrivers(false);   //Dehabilito los driver para ahorrar energia.
}

void InicializarMotores(){
  //Inicializo los pines a utilizar
  pinMode(PIN_PWMOUT_LEFT, OUTPUT);
  pinMode(PIN_PWMOUT_RIGHT, OUTPUT);
  pinMode(PIN_REVERSA_LEFT, OUTPUT);
  pinMode(PIN_REVERSA_RIGHT, OUTPUT);
  pinMode(PIN_ENABLE_LEFT, OUTPUT);
  pinMode(PIN_ENABLE_RIGHT, OUTPUT);

  //Detengo los motores y los pongo en directa
  MarchaAdelante();
  SetVelocidad(0);
  HabilitacionDrivers(false);   //Dehabilito los driver para ahorrar energia.
}


void SetVelocidad(byte velocidad){
  g_velocidad = velocidad;    //Esta variable solo es necesaria por el GetVelocidad
  HabilitacionDrivers(true);  //Habilito los drivers. Se habian deshabilitado para ahorrar energia.
  SetVelocidadMotorIzq(velocidad);
  SetVelocidadMotorDer(velocidad);  
}

byte GetVelocidad(){
  return g_velocidad;  
}

void SetVelocidadMotorIzq(byte velocidad){
  bool en_reversa = digitalRead(PIN_REVERSA_LEFT);
  
  if (en_reversa){                              //Si esta en reversa...
    analogWrite(PIN_PWMOUT_LEFT, (byte) ~velocidad);  //Invierto el PWM
  }
  else{
    analogWrite(PIN_PWMOUT_LEFT, velocidad);   //Si no, lo dejo como va
  }
}


void SetVelocidadMotorDer(byte velocidad){
  bool en_reversa = digitalRead(PIN_REVERSA_RIGHT);
  
  if (en_reversa)       
    analogWrite(PIN_PWMOUT_RIGHT, (byte) ~velocidad);
  else
    analogWrite(PIN_PWMOUT_RIGHT, velocidad);
}


void HabilitacionDrivers(bool habilitacion){
  digitalWrite(PIN_ENABLE_LEFT, habilitacion);
  digitalWrite(PIN_ENABLE_RIGHT, habilitacion);
}
