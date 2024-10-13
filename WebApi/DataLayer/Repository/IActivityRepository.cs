using ChatInteractionService.Database.Entities;

namespace MavJest.Repository
{
    public interface IActivityRepository
    {
        public List<ActivityHistory> GetActivityHistoryByStudentId(int studentId);
    }
}
