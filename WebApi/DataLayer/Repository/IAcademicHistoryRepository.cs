using ChatInteractionService.Database.Entities;

namespace DataLayer.Repository
{
    public interface IAcademicHistoryRepository
    {
        IEnumerable<AcademicHistory> GetStudentAcademicHistory(int id);
    }
}