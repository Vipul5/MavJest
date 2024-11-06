using WebAPIService.Models;

namespace WebAPIService.Business
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetAll();
    }
}