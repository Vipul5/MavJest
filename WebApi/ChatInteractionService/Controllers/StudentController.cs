using ChatInteractionService.Model;
using ChatInteractionService.Service;
using Microsoft.AspNetCore.Mvc;

namespace MavJest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public Student Get(int id)
        {
            return this.studentService.GetStudent(id);
        }
    }
}
