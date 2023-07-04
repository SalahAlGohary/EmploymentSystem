using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.DTOs.IdentityDTOs;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using EmploymentSystem.Domain;

namespace EmploymentSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vacancy, VacancyDto>().ReverseMap();
            CreateMap<Employer, EmployerDto>().ReverseMap();
            CreateMap<VacancyApplication, ApplicationDto>().ReverseMap();
            CreateMap<Applicant, ApplicantDto>().ReverseMap();
            CreateMap<RegisterRequestDto, User>()
           .ForMember(dest => dest.UserName,
               opt => opt.MapFrom(src => src.Email));
            CreateMap<PostVacancyRequestDto, Vacancy>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            CreateMap<UpdateVacancyRequestDto, Vacancy>()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<Vacancy, VacancyResponseDto>().ReverseMap();
           

        }
    }
}
