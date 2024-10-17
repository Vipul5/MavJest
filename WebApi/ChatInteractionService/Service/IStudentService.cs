using ChatInteractionService.Model;

namespace ChatInteractionService.Service
{
    public interface IStudentService
    {
        StudentViewModel GetStudent(int id);
    }
}