using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Infrastructure.Presistence;
using EmploymentSystem.Infrastructure.Services;

namespace EmploymentSystem.Infrastructure
{
    public static class InfrastuctureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<IApplicantService, ApplicantService>();

            var dbConnectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(dbConnectionString);
            });

            services.AddScoped<IApplicationDbContext>(
                provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
