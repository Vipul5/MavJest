using ChatInteractionService.Database.Entities;

namespace DataLayer.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student GetStudent(int id);
    }
}