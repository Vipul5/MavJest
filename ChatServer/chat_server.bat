@echo off

REM Check if ollama is installed by trying to run it
command -v ollama >nul 2>&1
if %errorlevel% neq 0 (
    echo Ollama is not installed on this machine.
    exit /b
)

echo Ollama is installed.

REM Execute "ollama pull phi3:mini" and print the command on console
echo Executing: ollama pull phi3:mini
ollama pull phi3:mini

REM Execute "ollama run phi3:mini" and print the command on console
echo Executing: ollama run phi3:mini
ollama run phi3:mini
