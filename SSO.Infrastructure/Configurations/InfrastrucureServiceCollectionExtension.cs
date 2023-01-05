using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSO.Core.Repositories;
using SSO.Core.Servcies;
using SSO.Infrastructure.DBContext;
using SSO.Infrastructure.Repositories;
using SSO.Infrastructure.Services;

namespace SSO.Infrastructure.Configurations
{
    public static class InfrastrucureServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("SSOConnectionString") != null)
            {
                services.AddDbContext<SSODbContext>(options =>
                          options.UseSqlServer(
                        Environment.GetEnvironmentVariable("SSOConnectionString"),
                        b => b.MigrationsAssembly(typeof(SSODbContext).Assembly.FullName)));
            }
            else
            {
                services.AddDbContext<SSODbContext>(options =>
                     options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(SSODbContext).Assembly.FullName)));
            }
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IUnitOfWork, SqlUnitOfWork>();
            
            services.AddTransient<IActiveDirectoryService, ActiveDirectoryService>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IAcademicYearRepository, AcademicYearRepository>();
            services.AddTransient<ITimeSchedulRepository, TimeSchedulRepository>();
            services.AddTransient<IUnitRepository, UnitRepository>();
            services.AddTransient<ITeachRepository, TeachRepository>();
            return services;
        }
    }
}
