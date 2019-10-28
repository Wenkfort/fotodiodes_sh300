const int relays [17] = {13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 14, 15, 16, 17, 18};
const int signalFromMultimeter [28] = {21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48};

volatile bool start = false;
volatile bool valueWasReceived = false;

volatile int value = 0;

void setup() {
  Serial.begin(9600);
  
  // Порты для управления реле настраиваютяс на выход
  // После инициализации на выходе 0В
  for (int i = 0; i < 17; i++){
    pinMode(relays[i], OUTPUT);
    digitalWrite(relays[i], LOW);
  }
  // Порты для принятия сигнала настраиваются на вход
  for(int i = 0; i < 28; i++){
    pinMode(signalFromMultimeter[i], INPUT);
  }
  
  // Прервание по нажатию кнопки "ПУСК", INT.2 PIN 21
  attachInterrupt(2, startProgramm, CHANGE);
}


void loop() {
  if (start){
    // readWriteAllValues();  закомменчено только для дебага

    //######## Код для дебага #######
    delay(1000);
    int count = 0;
    attachInterrupt(3, readOneValue, FALLING);
    while (valueWasReceived == false){
      count = 1;
      }
    valueWasReceived = false;
    Serial.print("; counter = ");
    Serial.println(count);
    //##### конец кода для дебага ####
    
    start = false;  // Программа выполняется всего 1 раз
    
    attachInterrupt(2, startProgramm, CHANGE); // Снова разрешили прерывание по нажатию кнпоки "ПУСК"
  }
  delay(500);
}

/*
void readWriteAllValues(){
  for (int i = 0; i < 17; i++){
    digitalWrite(relays[i], HIGH);
    delay(5);
    attachInterrupt(3, readOneValue, RISING);
    while (!valueWasReceived);  // Опасный момент, можем зависнуть здесь навсегда
  }
}
*/

void readOneValue() {
  detachInterrupt(3);
  for (int i = 1; i < 5; i++){
    value = digitalRead(signalFromMultimeter[i]);
    Serial.print(value);
  }
  valueWasReceived = true;
}

/*
// Обработчик прерывания по получению чего-то по UART
ISR (USART0_RX_vect){
   * тут будет более сложный код
  startProgramm();
}
*/

// сюда будут переходить прерывания от "ПУСК" и от "USART"
// дают "добро" на запуск программы
void startProgramm(){
  if (!start) start = true;
  detachInterrupt(2); // Запретили на всякий случай прервание по нажатию кнопки "ПУСК"
}
