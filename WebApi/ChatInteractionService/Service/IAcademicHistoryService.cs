using ChatInteractionService.Model;
using OllamaSharp;

namespace MavJest.Service
{
    public interface IAcademicHistoryService
    {
        void BootstrapStudentChat(OllamaApiClient ollama);
        Task<string> BriefAcademicSkill(int studentId);
        Task<StudentAcademicProfileViewModel> AcademicProfile(int studentId);
    }
}