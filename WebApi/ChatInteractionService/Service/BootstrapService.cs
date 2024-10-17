using DataLayer.Repository;
using MavJest.Service;
using Ollama;

namespace ChatInteractionService.Service
{
    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log the request
            Console.WriteLine("Request:");
            Console.WriteLine(request.Method + " " + request.RequestUri);
            if (request.Content != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                Console.WriteLine("Request Body:");
                Console.WriteLine(requestBody);
            }

            // Send the request to the inner handler and get the response
            var response = await base.SendAsync(request, cancellationToken);

            // Log the response
            Console.WriteLine("Response:");
            Console.WriteLine("Status Code: " + response.StatusCode);
            if (response.Content != null)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(responseBody);
            }

            return response;
        }
    }

    public class BootstrapService: IHostedService
    {
        private readonly IAcademicHistoryService academicHistoryService;
        private readonly IActivityService activityService;
        private readonly IBehaviourService behaviourService;
        private OllamaApiClient ollama;

        public BootstrapService(IAcademicHistoryService academicHistoryService, 
            IActivityService activityService,
            IBehaviourService behaviourService) { 
            this.academicHistoryService = academicHistoryService;
            this.activityService = activityService;
            this.behaviourService = behaviourService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this.ConnectToOllama();
            Console.WriteLine("Academic starting.");
            await academicHistoryService.BootstrapStudentChat(ollama);
            Console.WriteLine("Academic started.");
            //Console.WriteLine("Activity starting.");
            //await activityService.BootstrapStudentChat(ollama);
            //Console.WriteLine("Activity starting.");
            //Console.WriteLine("Behaviour starting.");
            //await behaviourService.BootstrapStudentChat(ollama);
            //Console.WriteLine("Behaviour starting.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task<OllamaApiClient> ConnectToOllama()
        {
            var uri = new Uri("http://localhost:11434");
            var loggingHandler = new LoggingHandler(new HttpClientHandler());
            HttpClient client = new HttpClient(loggingHandler);
            client.Timeout = TimeSpan.FromSeconds(600);
            ollama = new OllamaApiClient(client);
            var models = await ollama.Models.ListModelsAsync();

            // Pulling a model and reporting progress
            await foreach (var response in ollama.Models.PullModelAsync("phi3:mini", stream: true))
            {
                Console.WriteLine($"{response.Status}. Progress: {response.Completed}/{response.Total}");
            }

            // Generating an embedding
            var embedding = await ollama.Embeddings.GenerateEmbeddingAsync(
                model: "phi3:mini",
                prompt: "hello");

            Console.WriteLine("Server Connected. Ollama is Running and loaded.");

            return ollama;
        }

    }
}
