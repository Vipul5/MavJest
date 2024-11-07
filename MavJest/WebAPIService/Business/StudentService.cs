using MavJest.Database.Repository;
using MavJest.WebAPIService.Models;

namespace MavJest.WebAPIService.Business;

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

    public StudentDetailModel GetDetail(int id)
    {
        var student = this.studentRepository.GetStudent(id);
        return new StudentDetailModel
        {
            Id = student.Id,
            Name = student.Name,
            Image = student.Image
        };
    }
}
