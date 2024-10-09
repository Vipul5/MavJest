using ChatInteractionService.Database.Entities;

namespace MavJest.Service
{
    public interface IActivityService
    {
        ActivityDetails GetActivitySuggestion(int studentId);
    }
}
