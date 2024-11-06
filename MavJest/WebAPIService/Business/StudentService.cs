using DataLayer.Repository;
using WebAPIService.Models;

namespace WebAPIService.Business
{
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public IEnumerable<StudentModel> GetAll()
        {
            var students = this.studentRepository.GetAllStudents();
            IList<StudentModel> list = new List<StudentModel>();
            foreach (var student in students)
            {
                list.Add(new StudentModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                });
            }

            return list;
        }
    }
}
