using AutoMapper;
using EmploymentSystem.Application.DTOs;
using Domain = EmploymentSystem.Domain;

namespace EmploymentSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<Domain.Vacancy, VacancyDto>().ReverseMap();
                CreateMap<Domain.Employer, EmployerDto>().ReverseMap();
                CreateMap<Domain.Application, ApplicationDto>().ReverseMap();
                CreateMap<Domain.Applicant, ApplicantDto>().ReverseMap();
                
        }
    }
}
