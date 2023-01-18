import datetime
from socket import *
from time import sleep
import random
import json
import requests
import time
import RPi.GPIO as GPIO

serverName = '192.168.24.194'
serverPort = 12000


def randomzip():
    return random.randint(1000, 8000)


def randomestimate():
    if isfull():
        return random.randint(1, 30)
    else:
        return 0


def lastemptied():
    return datetime.datetime.now()


def isfull():
    mylist = [True, False]
    return random.choice(mylist)

def sensor():
    import time

    while True:
        try:
            GPIO.setmode(GPIO.BOARD)

            PIN_TRIGGER = 7
            PIN_ECHO = 11

            GPIO.setup(PIN_TRIGGER, GPIO.OUT)
            GPIO.setup(PIN_ECHO, GPIO.IN)

            GPIO.output(PIN_TRIGGER, GPIO.LOW)

            print ("Waiting for sensor to settle")

            time.sleep(2)

            print ("Calculating distance")

            GPIO.output(PIN_TRIGGER, GPIO.HIGH)

            time.sleep(0.00001)

            GPIO.output(PIN_TRIGGER, GPIO.LOW)

            while GPIO.input(PIN_ECHO) == 0:
                pulse_start_time = time.time()
            while GPIO.input(PIN_ECHO) == 1:
                pulse_end_time = time.time()

            pulse_duration = pulse_end_time - pulse_start_time
            distance = round(pulse_duration * 17150, 2)
            print ("Distance:", distance, "cm")
            if distance > 5:
                return False
            else:
                return True

        finally:
            GPIO.cleanup()

clientSocket = socket(AF_INET, SOCK_DGRAM)
clientSocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

while True:
    message = {"Id": 1, "City": "Roskilde", "Address": "Roskildevej 1", "ZipCode": randomzip(), "IsFull": sensor(),
               "Estimate": randomestimate(), "lastEmptied": "2022-11-02T10:34:00"}
    clientSocket.sendto(json.dumps(message).encode(), (serverName, serverPort))
    # response = requests.post(api_url, data=message)
    print(message)
    sleep(100)
