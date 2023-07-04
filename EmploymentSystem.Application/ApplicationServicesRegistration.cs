using EmploymentSystem.Application.DTOs.IdentityDTOs;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using EmploymentSystem.Application.DTOs.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<RegisterRequestDto>, RegisterRequestValidator>();
            services.AddTransient<IValidator<LoginRequestDto>, LoginRequestValidator>();
            services.AddTransient<IValidator<PostVacancyRequestDto>, VacancyRequestValidator>();
            services.AddTransient<IValidator<DeactivateVacancyDto>, DeactivateRequestValidator>();

            return services;
        }
    }
}
