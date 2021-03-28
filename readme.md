# Cops and Robbers Unity Game
Cops And Robbers is a fast-paced 2D multiplayer game developed using Unity2D. 
See www.copsandrobbers.co.uk

## Develop

### Requirements
* Unity 2019.4.6f1
* Visual Studio 2019 or JetBrains Rider
* A Mac, Windows, Linux or Android Device for testing (iOS hasn't been tested but it may also work fine)
## Set-Up
Import the project folder (`CopsAndRobbers`) into Unity Hub and then launch the project. By default, the `NetworkManager` is set to connect directly to our Google Cloud Server and therefore won't let you play by default. We recommend setting the server address to `localhost` or to your own server (port 7777 will need to be opened). You can set the server address through the `NetworkManager` found in the `Offline` Scene.

## Building a Server
To build a server, open build settings select standalone and the respective platform and tick the Server checkbox. On Linux this will compile to a file `Server.x86_64` which must be executed from the Terminal using the command:
```
./Server.x86_84
```
