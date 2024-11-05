using ChatInteractionService.Model;
using Ollama;

namespace ChatInteractionService.Service
{
    public class BootstrapService: IHostedService
    {
        private readonly ChatServerModel chatServerModel;

        public BootstrapService(
            ChatServerModel chatServerModel) {
            this.chatServerModel = chatServerModel;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this.ConnectToChatServer();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task ConnectToChatServer()
        {
            var uri = new Uri(chatServerModel.ChatServerUri);
            var httpHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(httpHandler);
            client.Timeout = TimeSpan.FromSeconds(600);
            client.BaseAddress = uri;
            chatServerModel.ChatApiClient = new OllamaApiClient(client);
            
            // Pulling a model and reporting progress
            await foreach (var response in chatServerModel.ChatApiClient.Models
                .PullModelAsync(chatServerModel.AIModel, stream: true))
            {
               Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
            }

            // Generating an embedding
            await chatServerModel.ChatApiClient.Embeddings.GenerateEmbeddingAsync(
                model: chatServerModel.AIModel,
                prompt: "hello");

            Console.WriteLine("Server Connected. Ollama is Running and loaded.");
        }

    }
}
