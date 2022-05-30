const int relays[17] = {13, 12, 11, 10, 9,  8,  7,  6, 5,
                        4,  3,  2,  14, 15, 16, 17, 18};
// const int signalFromMultimeter [28] = {22, 23, 24, 25, 26, 27, 28, 29, 30,
// 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 21};
const int signalFromMultimeter[28] = {45, 46, 39, 40, 38, 37, 36, 35, 34, 33,
                                      32, 31, 30, 29, 28, 27, 26, 25, 24, 23,
                                      22, 41, 42, 43, 44, 47, 48, 21};
volatile int value = 0;
volatile int numberOfRelay = 0;

void setup() {
  Serial.begin(9600);

  // Порты для управления реле настраиваютяс на выход
  // После инициализации на выходе 0В
  for (int i = 0; i < 17; i++) {
    pinMode(relays[i], OUTPUT);
    digitalWrite(relays[i], LOW);
  }
  // Порты для принятия сигнала настраиваются на вход
  for (int i = 0; i < 28; i++) {
    pinMode(signalFromMultimeter[i], INPUT);
  }
}

void loop() {
  char incomingChar;
  if (Serial.available() > 0) {
    incomingChar = Serial.read();
    switch (incomingChar) {
    case 'n':
      digitalWrite(relays[numberOfRelay], HIGH);
      break;
    case 'r':
      attachInterrupt(3, readValues, RISING);
      break;
    case 'e':
      numberOfRelay = 0;
      break;
    }
  }
}

void readValues() {
  for (int i = 0; i < 25; i++) {
    value = digitalRead(signalFromMultimeter[i]);
    Serial.print(value);
  }
  digitalWrite(relays[numberOfRelay++], LOW);
  detachInterrupt(3);
}
