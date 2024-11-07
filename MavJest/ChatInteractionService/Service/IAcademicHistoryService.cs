using MavJest.ChatInteractionService.Model;

namespace MavJest.ChatInteractionService.Service;

public interface IAcademicHistoryService
{
    Task<string> BriefAcademicSkill(int studentId);
    Task<StudentAcademicProfileViewModel> AcademicProfile(int studentId);
}