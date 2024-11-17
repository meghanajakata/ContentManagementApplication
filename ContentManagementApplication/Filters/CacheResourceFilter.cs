using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace ContentManagementApplication.Filters
{
    public class CacheResourceFilter : Attribute, IAsyncResourceFilter
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _expiration;
        public CacheResourceFilter(IMemoryCache cache)
        {
            _cache = cache;
            _expiration = TimeSpan.FromSeconds(60);
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            string cacheKey = context.HttpContext.Request.Path.ToString();
            if (_cache.TryGetValue(cacheKey, out ObjectResult cachedResponse))
            {
                context.Result = cachedResponse;
                return;
            }

            var executedContext = await next();

            if (executedContext.Result is ObjectResult okResult)
            {
                _cache.Set(cacheKey, okResult, _expiration);
            }
            var res = _cache.Get(cacheKey);
        }
    }
}
