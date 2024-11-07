using MavJest.ChatInteractionService.Model;
using MavJest.ChatInteractionService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MavJest.ChatInteractionService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BehaviourController : BaseController
{
    private readonly IBehaviourService behaviourService;
    public BehaviourController(IBehaviourService behaviourService, IMemoryCache cache)
        : base(cache)
    {
        this.behaviourService = behaviourService;
    }

    [HttpGet("title")]
    public async Task<string> GetTitle(int id)
    {
        string cacheKey = "BehaviourController_GetTitle_" + id;
        if (!_cache.TryGetValue(cacheKey, out string cachedData))
        {
            cachedData = await this.behaviourService.StudentTitle(id);

            _cache.Set(cacheKey, cachedData, _cacheExpiration);
        }

        return cachedData;
    }

    [HttpGet("summary")]
    public async Task<string> GetSummary(int id)
    {
        string cacheKey = "BehaviourController_GetSummary_" + id;
        if (!_cache.TryGetValue(cacheKey, out string cachedData))
        {
            cachedData = await this.behaviourService.BriefBehavior(id);

            _cache.Set(cacheKey, cachedData, _cacheExpiration);
        }

        return cachedData;
    }

    [HttpGet("profile")]
    public async Task<StudentBehaviourProfileViewModel> GetBehaviour(int id)
    {

        string cacheKey = "BehaviourController_GetBehaviour_" + id;
        if (!_cache.TryGetValue(cacheKey, out StudentBehaviourProfileViewModel cachedData))
        {
            cachedData = await this.behaviourService.StudentBehaviourDetail(id);

            _cache.Set(cacheKey, cachedData, _cacheExpiration);
        }

        return cachedData;
    }
}
