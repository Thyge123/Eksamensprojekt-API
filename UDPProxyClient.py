import datetime
from socket import *
from time import sleep
import random
import json
import requests
import time

serverName = '192.168.24.194'
serverPort = 12000


def randomzip():
    return random.randint(1000, 8000)


def randomestimate():
    isfull()
    if isfull():
        return random.randint(1, 30)
    else:
        return 0


def lastemptied():
    return datetime.datetime.now()


def isfull():
    mylist = [True, False]
    return random.choice(mylist)


clientSocket = socket(AF_INET, SOCK_DGRAM)
clientSocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

while True:
    message = {"Id": 1, "City": "By", "Address": "Vej", "ZipCode": randomzip(), "IsFull": isfull(),
               "Estimate": randomestimate(), "lastEmptied": datetime.datetime.now()}
    clientSocket.sendto(json.dumps(message).encode(), (serverName, serverPort))
    # response = requests.post(api_url, data=message)
    print(message)
    sleep(1)
