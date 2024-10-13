using ChatInteractionService.Model;

namespace ChatInteractionService.Service
{
    public interface IStudentService
    {
        Student GetStudent(int id);
    }
}