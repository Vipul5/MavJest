using MavJest.Database.Entities;

namespace MavJest.Database.Repository
{
    public interface IAcademicHistoryRepository
    {
        IEnumerable<AcademicHistory> GetStudentAcademicHistory(int id);
    }
}