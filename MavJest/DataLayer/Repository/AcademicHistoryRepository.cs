using MavJest.Database.Context;
using MavJest.Database.Entities;

namespace MavJest.Database.Repository
{
    public class AcademicHistoryRepository : IAcademicHistoryRepository
    {
        public IEnumerable<AcademicHistory> GetStudentAcademicHistory(int id)
        {
            using (var context = new MavJestContext())
            {
                var history = context.AcademicHistory.Where(st => st.StudentId == id);
                return history.ToList();
            }
        }
    }
}
