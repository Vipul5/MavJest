using DataLayer.Repository;
using MavJest.Service;
using OllamaSharp;

namespace ChatInteractionService.Service
{
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
            academicHistoryService.BootstrapStudentChat(ollama);
            activityService.BootstrapStudentChat(ollama);
            behaviourService.BootstrapStudentChat(ollama);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task<OllamaApiClient> ConnectToOllama()
        {
            var uri = new Uri("http://localhost:11434");
            ollama = new OllamaApiClient(uri);

            // select a model which should be used for further operations
            ollama.SelectedModel = "phi3:mini";

            var models = await ollama.ListLocalModels();

            await foreach (var status in ollama.PullModel("phi3:mini"))
                Console.WriteLine($"{status.Percent}% {status.Status}");

            Console.WriteLine("Server Connected. Ollama is Running and loaded.");

            return ollama;
        }

    }
}
