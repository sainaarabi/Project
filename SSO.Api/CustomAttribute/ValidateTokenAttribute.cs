using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json; 
using SSO.Common; 
using StackExchange.Redis;

namespace SSO.Api.CustomAttribute
{
    public class ValidateTokenAttribute : ActionFilterAttribute
    {
        private readonly IDatabase _redis = RedisStore.RedisCache;
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authorizationToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
          
        }

 
 
        public bool Exists(string key)
        {
            return _redis.KeyExists(key);
        }
    }
}