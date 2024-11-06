using ChatInteractionService.Database.Context;
using ChatInteractionService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
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
