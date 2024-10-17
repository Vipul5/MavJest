using ChatInteractionService.Model;
using OllamaSharp;

namespace MavJest.Service
{
    public interface IActivityService
    {
        void BootstrapStudentChat(OllamaApiClient ollama);
        Task<StudentActivityDetailViewModel> GetActivitySuggestion(int studentId);
        Task<StudentGroupViewModel> GetGroupForActivity();
        Task<string> GetActivityTitle(int studentId);
    }
}