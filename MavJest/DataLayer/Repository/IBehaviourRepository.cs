using ChatInteractionService.Database.Entities;

namespace DataLayer.Repository
{
    public interface IBehaviourRepository
    {
        IEnumerable<BehaviourHistory> GetStudentBehaviorHistory(int id);
    }
}