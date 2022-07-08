
void ManejadorDeComandos(int incomingByte){
  
    switch (incomingByte) {
    case '1':
      Serial.println(F("1: Distancias[cm]"));
      Serial.print(F("  -Izq: ")); Serial.println(LeerSonarIzquierdo(), DEC); delay(80);
      Serial.print(F("  -Med: ")); Serial.println(LeerSonarMedio(), DEC); delay(80);
      Serial.print(F("  -Der: ")); Serial.println(LeerSonarDerecho(), DEC); delay(80);
      break;
    case 'e':
      g_modo = MANUAL;
      InicializarMotores();   //Inicializo los motores nuevamente
      Serial.println(F("e: Modo MANUAL On"));
      break;
    case 'c':
      g_modo = AUTOMATICO;
      Serial.println(F("c: Modo AUTO On"));
      break; 
    case 'f':
      g_modo = ANALIZADOR;
      Serial.println(F("c: Modo ANALIZADOR On"));
      break;
    case 'r':
      g_modo = REC_NOTAS;
      Serial.println(F("c: Modo RECONOCIM. DE NOTAS On"));
      break;
  
    //*********Comandos solo disponibles para el modo manual.*********
    case 'w':
      if (g_modo == MANUAL){
        MarchaAdelante();
        Serial.println(F("w: Marcha ADELANTE"));
      }
      break;
    case 'x':
      if (g_modo == MANUAL){
        MarchaAtras();
        Serial.println(F("x: Marcha ATRAS"));
      }
      break;
    case 'a':
      if (g_modo == MANUAL){
        GirarALaIzquierda();
        Serial.println(F("a: Giro IZQUIERDA"));
      }
      break;
    case 'd':
      if (g_modo == MANUAL){
        GirarALaDerecha();
        Serial.println(F("d: Giro DERECHA"));
      }
      break;
    case 's':
      if (g_modo == MANUAL){
        Detener();
        Serial.println(F("s: STOP"));
      }
      break;
    case 'q':
      if (g_modo == MANUAL){
        if (GetVelocidad() == 0) SetVelocidad(VELOCIDAD_MINIMA); 
        else if (GetVelocidad() < VELOCIDAD_MAXIMA) SetVelocidad(GetVelocidad() + 25);
        Serial.print(F("q: Incremento VELOCIDAD: "));  Serial.println(GetVelocidad(), DEC);
      }
      break; 
    case 'z':
      if (g_modo == MANUAL){
        if (GetVelocidad() > VELOCIDAD_MINIMA) SetVelocidad(GetVelocidad() - 25);
        Serial.print(F("z: Decremento VELOCIDAD: "));  Serial.println(GetVelocidad(), DEC);
      }
      break;
    default:
      if (incomingByte != '\n' && incomingByte != '\r')
        Serial.println(F("Comando desconocido"));      
    }
}
