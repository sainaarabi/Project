using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SSO.Application.Configuration.Commands;

namespace SSO.Application.Configurations
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, Type type)
        {
            services.AddMediatR(type, typeof(CommandBase));
            services.AddMediatR(type, typeof(CommandBase<>));
            return services;
        }
    }
}
