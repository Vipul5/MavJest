using ChatInteractionService.Model;
using ChatInteractionService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatInteractionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : BaseController
    {
        private readonly IAcademicHistoryService academicHistoryService;
        public AcademicController(IAcademicHistoryService academicHistoryService, IMemoryCache cache)
        : base(cache)
        {
            this.academicHistoryService = academicHistoryService;
        }

        [HttpGet("title")]
        [OutputCache(Duration = 60, VaryByQueryKeys = ["id"])]
        public async Task<string> GetAcademicTitle(int id)
        {
            string cacheKey = "AcademicController_GetAcademicTitle_" + id;
            if (!_cache.TryGetValue(cacheKey, out string cachedData))
            {
                cachedData = await this.academicHistoryService.BriefAcademicSkill(id);

                _cache.Set(cacheKey, cachedData, _cacheExpiration);
            }

            return cachedData;
        }

        [HttpGet("profile")]
        public async Task<StudentAcademicProfileViewModel> GetAcademicProfile(int id)
        {
            string cacheKey = "AcademicController_GetAcademicProfile_" + id;
            if (!_cache.TryGetValue(cacheKey, out StudentAcademicProfileViewModel cachedData))
            {
                cachedData = await this.academicHistoryService.AcademicProfile(id);
                _cache.Set(cacheKey, cachedData, _cacheExpiration);
            }

            return cachedData;
        }
    }
}
