namespace MavJest.ChatInteractionService.Service;

public interface IActivityService
{
    Task<string> BriefBehavior(int studentId);
    Task<string> BriefParticipation(int studentId);
}
