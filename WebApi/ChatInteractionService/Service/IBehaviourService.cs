
namespace ChatInteractionService.Service
{
    public interface IBehaviourService
    {
        Task<string> StudentTitle(int studentId);
        Task<string> BriefBehavior(int studentId);
    }
}