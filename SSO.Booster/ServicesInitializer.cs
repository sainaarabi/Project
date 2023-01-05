using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSO.Application.Configurations;
using SSO.Infrastructure.Configurations;

namespace SSO.Booster
{
    public static class ServicesInitializer
    {
        public static IServiceCollection AddInitializer(this IServiceCollection services,
            IConfiguration configuration, Type type)
        {
            services.AddInfrastructure(configuration);
            services.AddApplication(type);
            return services;
        }
    }
}