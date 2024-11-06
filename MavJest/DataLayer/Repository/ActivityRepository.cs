using ChatInteractionService.Database.Entities;
using ChatInteractionService.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace MavJest.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        public List<ActivityHistory> GetActivityHistoryByStudentId(int studentId)
        {
            //read the data
            using (var context = new MavJestContext())
            {

                // Get a specific student's activities
                var activities = context.ActivityHistory
                                         .Where(a => a.StudentId == 1)
                                         .Include(x => x.ActivityDetails)
                                         .ToList();
                return activities;
            }
        }



    }
}
