using MavJest.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatInteractionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        private readonly IAcademicHistoryService academicHistoryService;
        public AcademicController(IAcademicHistoryService academicHistoryService)
        {
            this.academicHistoryService = academicHistoryService;
        }
        [HttpGet("title")]
        public async Task<string> GetAcademicTitle(int id)
        {
            return await this.academicHistoryService.BriefAcademicSkill(id);
        }

        // GET: api/<AcademicController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AcademicController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AcademicController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AcademicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcademicController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
