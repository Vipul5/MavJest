using MavJest.Database.Entities;

namespace MavJest.Database.Repository
{
    public interface IActivityRepository
    {
        public List<ActivityHistory> GetActivityHistoryByStudentId(int studentId);
    }
}
