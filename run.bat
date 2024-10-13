start bash -c "./ChatServer/chat_server.sh"
cd ./WebApi
start bash -c "dotnet run; exec bash"
start "" "../WebApi/WebApp/index.html"

