using ChatInteractionService.Model;
using Ollama;

namespace MavJest.Service
{
    public interface IActivityService
    {
        Task BootstrapStudentChat(OllamaApiClient ollama);
        Task<StudentActivityDetailViewModel> GetActivitySuggestion(int studentId);
        Task<StudentGroupViewModel> GetGroupForActivity();
        Task<string> GetActivityTitle(int studentId);
    }
}