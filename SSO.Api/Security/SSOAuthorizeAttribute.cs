using Microsoft.AspNetCore.Mvc.Filters;
using SSO.Api.Exceptions;
using SSO.Api.Model;
using SSO.Api.Security.Identities;
using System.Security.Claims;
using System.Security.Principal;

namespace SSO.Api.CustomAttribute
{
    public class SSOAuthorize : ActionFilterAttribute
    {
        public enum Role
        {
            Null,
            SuperAdmin,
            Admin,
            Author,
            Member,
            Plaintiff
        }

        public List<Role> Roles { get; set; }

        public SSOAuthorize(Role role)
        {
            this.Roles = new List<Role>() { role };
        }
        public SSOAuthorize(params Role[] roles)
        {
            this.Roles = roles.ToList();
        }
        public SSOAuthorize()
        {
            Roles = null;
        }

        public override async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var jwtHelper = (IJWTHelper)context.HttpContext.RequestServices.GetService(typeof(IJWTHelper));
            string token = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
                throw new MissingTokenException();
            AthenticatedUser user = null;
            var jwtSecurityKey =
                ((IConfiguration)context.HttpContext.RequestServices.
                GetService(typeof(IConfiguration))).GetSection("JWTSecurityKey").Value;
            var isValidate = jwtHelper.ValidateToken(token, out user, jwtSecurityKey);
            if (!isValidate)
                throw new ForbidenAccessException();
            if ((Roles != null && Roles.Any()) && !user.Roles.Any())
                throw new NotAuthorizedException();
            if (Roles == null || !Roles.Any())
            {
                var identities = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.MobilePhone,user.MobileNo),
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
                });
                context.HttpContext.User = new GenericPrincipal(identities,
                    user?.Roles?.ToArray());
            }
            else
            {
                var hasRequiredRole = false;
                var requiredRoles = Roles.Select(x => x.ToString());
                foreach (var role in requiredRoles)
                {
                    hasRequiredRole = user.Roles.Contains(role);
                    if (hasRequiredRole)
                        break;
                }
                if (!hasRequiredRole)
                    throw new NotAuthorizedException();
                var appIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.MobilePhone,user.MobileNo),
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
                });
                context.HttpContext.User = new GenericPrincipal(appIdentity,
                    user?.Roles?.ToArray());
            }
            await next();
        }
    }
}
