using MavJest.Database.Context;
using MavJest.Database.Entities;

namespace MavJest.Database.Repository
{
    public class BehaviourRepository : IBehaviourRepository
    {
        public IEnumerable<BehaviourHistory> GetStudentBehaviorHistory(int id)
        {
            using (var context = new MavJestContext())
            {
                var history = context.BehaviourHistory.Where(st => st.StudentId == id);
                return history.ToList();
            }
        }
    }
}
