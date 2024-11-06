using ChatInteractionService.Controllers;
using ChatInteractionService.Model;
using ChatInteractionService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;
using OllamaSharp;
using OllamaSharp.Models.Chat;
using System.Text;
using System.Text.Json;

namespace MavJest.Controllers
{
    [Route("/api/[controller]")]
    public class ActivityController : BaseController
    {
        private readonly IActivityService _activityService;

        public ActivityController( IActivityService activityService, IMemoryCache cache)
        :base(cache)
        {
            _activityService = activityService;
        }

        [HttpGet("summary")]
        public async Task<string> GetSummary(int id)
        {
            string cacheKey = "ActivityController_GetSummary_" + id;
            if (!_cache.TryGetValue(cacheKey, out string cachedData))
            {
                cachedData = await this._activityService.BriefBehavior(id);

                _cache.Set(cacheKey, cachedData, _cacheExpiration);
            }

            return cachedData;
        }

        [HttpGet("participation")]
        public async Task<string> GetParticipation(int id)
        {
            string cacheKey = "ActivityController_GetParticipation_" + id;
            if (!_cache.TryGetValue(cacheKey, out string cachedData))
            {
                cachedData = await this._activityService.BriefParticipation(id);

                _cache.Set(cacheKey, cachedData, _cacheExpiration);
            }

            return cachedData;
        }
    }
}
