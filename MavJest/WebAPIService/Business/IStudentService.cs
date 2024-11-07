using MavJest.WebAPIService.Models;

namespace MavJest.WebAPIService.Business;

public interface IStudentService
{
    IEnumerable<StudentModel> GetAll();

    StudentDetailModel GetDetail(int id);
}