using ChatInteractionService.Database.Context;
using ChatInteractionService.Database.Entities;

namespace DataLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetAllStudents()
        {
            using (var context = new MavJestContext())
            {
                var students = context.Student.ToList();
                return students;
            }
        }

        public Student GetStudent(int id)
        {
            using (var context = new MavJestContext())
            {
                var student = context.Student.First(st => st.Id == id);
                return student;
            }
        }
    }
}
