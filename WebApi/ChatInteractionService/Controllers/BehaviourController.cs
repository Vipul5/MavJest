using ChatInteractionService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatInteractionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BehaviourController : ControllerBase
    {
        private readonly IBehaviourService behaviourService;
        public BehaviourController(IBehaviourService behaviourService)
        {
            this.behaviourService = behaviourService;
        }

        [HttpGet("title")]
        public async Task<string> GetTitle(int studentId)
        {
            return await this.behaviourService.TitleText(studentId);
        }
    }
}
