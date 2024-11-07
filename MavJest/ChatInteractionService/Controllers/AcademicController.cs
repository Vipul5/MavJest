using MavJest.ChatInteractionService.Model;
using MavJest.ChatInteractionService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MavJest.ChatInteractionService.Controllers;

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

    [HttpGet("summary")]
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
