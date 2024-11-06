using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ChatInteractionService.Controllers
{
    public class BaseController: ControllerBase
    {
        protected readonly IMemoryCache _cache;
        protected readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(60); // Set cache expiration time

        public BaseController(IMemoryCache cache)
        {
            _cache = cache;
        }
    }
}
