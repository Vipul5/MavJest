using ChatInteractionService.Database.Context;
using ChatInteractionService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
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
