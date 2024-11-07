using MavJest.Database.Entities;

namespace MavJest.Database.Repository
{
    public interface IBehaviourRepository
    {
        IEnumerable<BehaviourHistory> GetStudentBehaviorHistory(int id);
    }
}