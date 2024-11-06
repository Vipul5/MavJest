@echo off

REM Step 1: Navigate to the webapi folder and run dotnet
cd /d "./WebApi" 
echo Running dotnet in the webapi folder...
dotnet run

REM Step 2: Open webapp/index.html in the default browser
start "" "./WebApi/WebApp/index.html"

REM Step 3: Call ollama_checker.bat in a new window
start cmd /k "./ChatServer/chat_server.bat"