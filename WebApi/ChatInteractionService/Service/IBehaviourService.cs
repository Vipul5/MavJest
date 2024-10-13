using OllamaSharp;

namespace ChatInteractionService.Service
{
    public interface IBehaviourService
    {
        void BootstrapStudentChat(OllamaApiClient ollama);
        Task<string> TitleText(int studentId);
    }
}