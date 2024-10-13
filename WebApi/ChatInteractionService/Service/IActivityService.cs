using ChatInteractionService.Model;
using OllamaSharp;

namespace MavJest.Service
{
    public interface IActivityService
    {
        void BootstrapStudentChat(OllamaApiClient ollama);
        Task<StudentActivityDetail> GetActivitySuggestion(int studentId);
        Task<StudentGroup> GetGroupForActivity();
        Task<string> GetActivityTitle(int studentId);
    }
}