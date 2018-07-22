#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN 10
#define RST_PIN 9
 
MFRC522 rfid(SS_PIN, RST_PIN); // Instance of the class

MFRC522::MIFARE_Key key;

String mySt;
 int i=0;
 boolean formConnection = false;

// Init array that will store new NUID
byte nuidPICC[4];

void setup() {
  Serial.begin(19200);
  delay(2000);
  Serial.setTimeout(100);
  SPI.begin(); // Init SPI bus
  rfid.PCD_Init(); // Init MFRC522
  //Set key bytes to nothing
  for (byte i = 0; i < 6; i++) {
    key.keyByte[i] = 0xFF;
  }

 
}
 
void loop() {
while(Serial.available()){
  //Wait for visual studio to send '-' to the com port connected by this device and send return handshake;TODO: Currently, Device doesn't reset this form connection variable
  delay(1);
  if(Serial.available() > 0){
    char c = Serial.read();
    if(c == '-'){
      Serial.print("OK");
      formConnection = true;
      Serial.flush ();
    }
  }
}



if(formConnection == true){
  // Look for new cards
  if ( ! rfid.PICC_IsNewCardPresent())
    return;

  // Verify if the NUID has been read
  if ( ! rfid.PICC_ReadCardSerial())
    return;



 for (byte i = 0; i < 4; i++) {
      nuidPICC[i] = rfid.uid.uidByte[i];
    }

   //send bytes over serial to visual studio form
  printHex(rfid.uid.uidByte, rfid.uid.size);
    //Serial.println();
   rfid.PICC_HaltA();

 
  rfid.PCD_StopCrypto1();
  }
}



void printHex(byte *buffer, byte bufferSize) {
  for (byte i = 0; i < bufferSize; i++) {
    Serial.print(buffer[i] < 0x10 ? " 0" : " ");
    Serial.print(buffer[i], HEX);
  }
}

