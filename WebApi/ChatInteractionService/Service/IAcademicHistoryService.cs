using ChatInteractionService.Model;
using Ollama;

namespace MavJest.Service
{
    public interface IAcademicHistoryService
    {
        Task BootstrapStudentChat(OllamaApiClient ollama);
        Task<string> BriefAcademicSkill(int studentId);
        Task<StudentAcademicProfileViewModel> AcademicProfile(int studentId);
    }
}