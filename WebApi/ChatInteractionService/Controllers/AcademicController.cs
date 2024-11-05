using ChatInteractionService.Model;
using MavJest.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

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
        [OutputCache(Duration = 60, VaryByQueryKeys = ["id"])]
        public async Task<string> GetAcademicTitle(int id)
        {
            return await this.academicHistoryService.BriefAcademicSkill(id);
        }

        [HttpGet("profile")]
        [OutputCache(Duration = 60, VaryByQueryKeys = ["id"])]
        public async Task<StudentAcademicProfileViewModel> GetAcademicProfile(int id)
        {
            return await this.academicHistoryService.AcademicProfile(id);
        }
    }
}
