
void ManejadorDeComandos(int incomingByte){

    switch (incomingByte) {
    case '1':
      Serial.println(F("1: Distancias[cm]"));
      Serial.print(F("  -Izq: ")); Serial.println(LeerSonarIzquierdo(), DEC); delay(80);
      Serial.print(F("  -Med: ")); Serial.println(LeerSonarMedio(), DEC); delay(80);
      Serial.print(F("  -Der: ")); Serial.println(LeerSonarDerecho(), DEC); delay(80);
      break;
    case '2':
      WriteIntIntoEEPROM(ADDR_DEAMBULACIONES_COUNTER, 0);
      Serial.println(F("2: Cont. deambul. reseteado."));    
      break;
    case '3':
      Serial.print(F("3: #Deambulaciones: "));  
      Serial.println(ReadIntFromEEPROM(ADDR_DEAMBULACIONES_COUNTER), DEC);
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

//Si se declaran variables locals dentro del case, compila, pero falla en tiempo de ejecucion. BUG Extrano. 
//Se comprobo que no era falta de memoria, ya que se declararon
//arriba de switch multiples int y se los incremento y uso dentro de case, pero no hubo ningun problema.
//la falla solo surgia cuando se declara dentro eel case.
//https://forum.arduino.cc/t/why-cant-i-declare-a-local-variable-in-a-switch-case/64115/6 
//Al parecer, solo se puede declarar variables locals si se usa {} para encerrar el contenido del case
