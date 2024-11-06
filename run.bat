@echo off
REM Step 0: Call ollama_checker.bat in a new window
cd /d "./ChatServer"
start cmd /k "chat_server.bat"

timeout /t 5 /nobreak >nul

REM Step 1: Navigate to the webapi folder and run dotnet
cd /d "../MavJest/WebAPIService" 
echo Running dotnet in the webapi folder...
start cmd /k "dotnet run"

timeout /t 5 /nobreak >nul

REM Step 2: Navigate to the chatservice folder and run dotnet
cd /d "../ChatInteractionService" 
echo Running dotnet in the chat service folder...
start cmd /k "dotnet run"

timeout /t 5 /nobreak >nul

REM Step 3: Open webapp/index.html in the default browser
start "" "../WebApp/index.html"

