using MavJest.WebAPIService.Business;
using MavJest.WebAPIService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MavJest.WebAPIService.Controller;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService studentService;
    public StudentController(IStudentService studentService)
    {
        this.studentService = studentService;
    }

    [HttpGet]
    public IEnumerable<StudentModel> Get()
    {
        return this.studentService.GetAll();
    }

    [HttpGet("{id}")]
    public StudentDetailModel Get(int id)
    {
        return this.studentService.GetDetail(id);
    }
}
