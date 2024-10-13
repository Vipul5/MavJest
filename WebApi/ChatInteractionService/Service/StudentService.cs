using ChatInteractionService.Model;
using DataLayer.Repository;

namespace ChatInteractionService.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Student GetStudent(int id)
        {
            var student = this.studentRepository.GetStudent(id);
            return new Student
            {
                Id = student.Id,
                Name = student.Name
            };
        }
    }
}
