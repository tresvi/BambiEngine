
void ControlDeambulacion(){
  //Inicializo los motores a la velocidad corresp.
  SetVelocidad(VELOCIDAD_DEAMBULACION);
  
  delay(45);
  long distancia_izq = LeerSonarIzquierdo();
  delay(45);
  long distancia_medio = LeerSonarMedio();    
  delay(45);
  long distancia_der = LeerSonarDerecho();
  
  if (distancia_izq <= DISTANCIA_MIN_PARA_GIRAR || distancia_medio <= DISTANCIA_MIN_PARA_GIRAR){
    if (distancia_der >= DISTANCIA_MIN_PARA_GIRAR){
      GirarALaDerecha();
    }
    else {
      MarchaAtras();
      delay(3000);
    }
  } 
  else if (distancia_der <= DISTANCIA_MIN_PARA_GIRAR){
    if (distancia_izq >= DISTANCIA_MIN_PARA_GIRAR){
      GirarALaIzquierda();
    }
    else {
      MarchaAtras();
      delay(2000);
    }
  }   
  else {
    MarchaAdelante();  
  } 

  return;
}
