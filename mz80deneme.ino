int sensorState = 0;
int lastSensorState = 0;
int counter = 0;
int  set = 0;
const int buzzerPin = 13;
const int sensorPin = 0;

void setup() {
  pinMode(buzzerPin, OUTPUT);
  pinMode(sensorPin, INPUT);
  Serial.begin(9600);
}

void loop() {
 // int sensorPin = analogRead(0);
 // sensorPin = map(sensorPin,0,1023,0,25);
  sensorState = analogRead(sensorPin);
  if (sensorState != lastSensorState)
  {
    if (sensorState < 200)
    {
      digitalWrite(buzzerPin, HIGH);
      if(set != 1)
      {
      set = 1;
       counter++;
      Serial.print("on  ");
      Serial.print("number of objects:  ");
      Serial.print(sensorState);
      Serial.print("     ");
      Serial.println(counter);
    
      }
    }
    else 
    {
      set = 0;
      digitalWrite(buzzerPin, LOW);
    
    
    
    
    }
  }
  lastSensorState = sensorState;
}
