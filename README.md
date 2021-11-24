# LightsOut
Lights Out is a puzzle game developed in C#. The purpose of the game is to switch all the lights off.

## Developed Using
- .NET 5
- Visual Studio 2019 version 16.11.7
- SQL Server 2017 Express version 14.0.1000

## Getting Started

### Creating database tables
Create a database called `LightsOut` on SQL Server. Run the Migration-Scripts.sql under \sql folder on the created db.

### Runnig Rest Api
Set LightsOut.Api as start up project. Build the project. Run the LightsOut.Api.Exe under project \bin folder. Rest Api will be served under http://localhost:5000 base url. 

http://localhost:5000/api/gamesettings/1

### Running Windows Forms Application
Set LightsOut.App as start up project. Build the project. Run the LightsOut.App.Exe under project \bin folder.

## Test Cases

LightsOut rest api test cases is under tests folder.
