# MavJest
MavJest is a Hacktelligence submission, in Nagarro - NAGP.

# Idea
The Educational Institute App is designed
to help teachers easily track and manage
important student information. Teachers
will be able to record details like where
students sit, how they are performing, and
how they behave in class. Based on this
information, the app will also provide
suggestions for seating arrangements,
activities, and hobbies, and even give
personalized feedback to help with the
child’s overall development. This app will
make the teacher’s job easier and support
the growth of each student.

# Run Application Locally
## Prerquisites
- Dotnet 8.0 SDK: to build the application in dotnet 8 runtime and use dotnet 8 runtime to execute. Link to download: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- Ollama: Ollama is used as a generative AI development server which can work as a chat server running in your system. Link to download: https://ollama.com/download/windows

## Ports used
Make sure following ports are available for application to run, or change them in launch settings by creating your own profile, or modifying the existing ones.
- Default port of Ollama server - 11434
- Chat service port - 9001, 9002
- WebAPI service port - 8001, 8002

## Run this application locally
The easiest way to run this application is navigate to root folder and from powershell execute following command:
```batch
./run.bat
```
Step by step guide to run the application (If you are running this application using run.bat, these steps are not required).
- Step-1: Open a command prompt and run Ollama Server in command prompt. Refer this [Microsoft Link]([https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/quickstart-local-ai) or below Commands to run ollama server:
```batch
ollama pull phi3:mini
ollama run phi3:mini
```
https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/quickstart-local-ai
- Step-2: Navigate to WebAPI folder and run. Open another command prompt and run following commands:
```batch
cd ./MavJest/WebAPIService
dotnet run
```
- Step-3: Navigate to Chatservice folder and run. Open another command prompt and run following commands:
```batch
cd ./MavJest/ChatInteractionService
dotnet run
```
- Step-3: Run your application from ./MavJest/index.html
