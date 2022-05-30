const int relays[17] = {13, 12, 11, 10, 9,  8,  7,  6, 5,
                        4,  3,  2,  14, 15, 16, 17, 18};
const int signalFromMultimeter[28] = {21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                                      31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                                      41, 42, 43, 44, 45, 46, 47, 48};

volatile bool start = false;
volatile bool valueWasReceived = false;

volatile int value = 0;

volatile bool state = false;

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

  // Прервание по нажатию кнопки "ПУСК", INT.2 PIN 21
  // attachInterrupt(2, startProgramm, RISING);
}

void loop() {
  char IncomingChar;

  if (Serial.available() > 0) {
    IncomingChar = Serial.read();
    switch (IncomingChar) {
    case '1':
      for (int j = 0; j < 6; j++)
        for (int i = 0; i < 4; i++)
          Serial.print(random(0, 2));
      break;
    case '0':
      break;
    }
  }
  delay(300);
}

void readOneValue() {
  detachInterrupt(3);
  for (int i = 1; i < 5; i++) {
    value = digitalRead(signalFromMultimeter[i]);
    Serial.print(value);
  }
  Serial.println();
  attachInterrupt(2, startProgramm, RISING);
}

// сюда будут переходить прерывания от "ПУСК" и от "USART"
// дают "добро" на запуск программы
void startProgramm() {
  detachInterrupt(2);
  attachInterrupt(3, readOneValue, RISING);
}
