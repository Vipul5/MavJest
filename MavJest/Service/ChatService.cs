using OllamaSharp;
using OllamaSharp.Models.Chat;
using System.Text.Json;

namespace MavJest.Service
{
    public class ChatService : IChatService
    {
        public IList<Message> convertFiletoJSON(string fileName)
        {
            var data = File.ReadAllText(fileName);
            var array = JsonSerializer.Deserialize<dynamic[]>(data);
            List<Message> messages = new List<Message>();
            Console.WriteLine("Reading Records...");
            for (var i = 0; i < array.Length; i++)
            {
                string json = JsonSerializer.Serialize(array[i]);
                messages.Add(new Message(ChatRole.System, json));
                Console.WriteLine($"{i} - Record Loaded");
            }
            return messages;

        }

        public async Task<OllamaApiClient> connectToOllama()
        {
            var uri = new Uri("http://localhost:11434");
            var ollama = new OllamaApiClient(uri);

            // select a model which should be used for further operations
            ollama.SelectedModel = "phi3:mini";

            var models = await ollama.ListLocalModels();

            await foreach (var status in ollama.PullModel("phi3:mini"))
                Console.WriteLine($"{status.Percent}% {status.Status}");

            Console.WriteLine("Server Connected. Ollama is Running and loaded.");

            return ollama;
        }

        public void convertSQLDatatoJSON()
        {

        }

        public IList<Message> createJSONData()
        {
            return null;
        }
    }
}
