using Ollama;

namespace ChatInteractionService.Service
{
    public interface IBehaviourService
    {
        Task BootstrapStudentChat(OllamaApiClient ollama);
        Task<string> TitleText(int studentId);
    }
}