using SSO.Api.Security.Identities;

namespace SSO.Api.Security
{
    public static class SecurityExtension
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddScoped<IJWTHelper, JWTHelper>();
            return services;
        }
    }
}
