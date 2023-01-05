using System.Net;

namespace SSO.Api.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.ToLower().Contains("signup") ||
                httpContext.Request.Path.Value.ToLower().Contains("groups") ||
                httpContext.Request.Path.Value.ToLower().Contains("properties"))
            {
                await _next(httpContext);
                return;
            }
            if (httpContext.Request.Headers.Keys.Contains("token"))
            {
                var token = httpContext.Request.Headers["token"];            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await httpContext.Response.WriteAsync("Token is missing");
                return;
            }
            await _next(httpContext);
        }
    }
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
