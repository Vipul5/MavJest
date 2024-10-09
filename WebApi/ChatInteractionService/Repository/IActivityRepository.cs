using ChatInteractionService.Database.Entities;
using OllamaSharp;
using OllamaSharp.Models.Chat;

namespace MavJest.Repository
{
    public interface IActivityRepository
    {
        public List<ActivityHistory> GetActivityHistoryByStudentId(int studentId);
    }
}
