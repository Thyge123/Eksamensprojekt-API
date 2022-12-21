from socket import *
import requests
import json

serverPort = 12000
serverSocket = socket(AF_INET, SOCK_DGRAM)


headers = {'Content-type': 'application/json'}


serverAddress = ('', serverPort)

serverSocket.bind(serverAddress)
print("The server is ready")
while True:
    message, clientAddress = serverSocket.recvfrom(2048)
    decoded_message = message.decode()
    x = json.loads(decoded_message)
    id = str((x["Id"]))
    # print(x["Id"])
    api_url = "http://localhost:5124/api/TrashCans/" + id
    # Using data and headers instead of json, as the data is already json encoded, using json= would
    # double encode it, and would not be a valid object.
    response = requests.put(api_url, decoded_message, headers=headers)
    # print(response.content)
    print(response.status_code)
