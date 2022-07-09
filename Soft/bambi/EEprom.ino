#include <EEPROM.h>

void IncContadorDeambulaciones(){
  int valor_actual = ReadIntFromEEPROM(ADDR_DEAMBULACIONES_COUNTER);
  WriteIntIntoEEPROM(ADDR_DEAMBULACIONES_COUNTER, ++valor_actual);
}

void WriteUnsignedIntIntoEEPROM(int address, unsigned int number)
{ 
  EEPROM.write(address, number >> 8);
  EEPROM.write(address + 1, number & 0xFF);
}

unsigned int ReadUnsignedIntFromEEPROM(int address)
{
  return (EEPROM.read(address) << 8) + EEPROM.read(address + 1);
}

int ReadIntFromEEPROM(int address)
{
  byte byte1 = EEPROM.read(address);
  byte byte2 = EEPROM.read(address + 1);
  return (byte1 << 8) + byte2;
}


void WriteIntIntoEEPROM(int address, int value)
{ 
  EEPROM.write(address, value >> 8);
  EEPROM.write(address + 1, value & 0xFF);
}
