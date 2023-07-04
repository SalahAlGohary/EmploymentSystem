using EmploymentSystem.Domain;
using EmploymentSystem.Infrastructure.Presistence;
using Microsoft.AspNetCore.Identity;

namespace EmploymentSystem.API.ServiceExtensions;

public static class IdentityServicesExtension
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, UserRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        services.AddScoped<UserManager<User>>();
        services.AddAuthorization();
        return services;
    }
}
