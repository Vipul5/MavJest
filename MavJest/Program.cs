using OllamaSharp;

var uri = new Uri("http://localhost:11434");
var ollama = new OllamaApiClient(uri);

// select a model which should be used for further operations
ollama.SelectedModel = "phi3:mini";

var models = await ollama.ListLocalModels();

await foreach (var status in ollama.PullModel("phi3:mini"))
    Console.WriteLine($"{status.Percent}% {status.Status}");

Console.WriteLine("Server Connected. Ollama is Running and loaded.");

var chat = new Chat(ollama);
while (true)
{
    var message = Console.ReadLine();
    await foreach (var answerToken in chat.Send(message))
        Console.Write(answerToken);
}
