using ChatInteractionService.Model;
using Ollama;

namespace ChatInteractionService.Service
{
    public interface IAcademicHistoryService
    {
        Task<string> BriefAcademicSkill(int studentId);
        Task<StudentAcademicProfileViewModel> AcademicProfile(int studentId);
    }
}