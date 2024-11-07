using MavJest.Database.Entities;

namespace MavJest.Database.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student GetStudent(int id);
    }
}