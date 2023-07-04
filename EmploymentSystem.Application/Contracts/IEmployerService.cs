using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts
{
    public interface IEmployerService
    {
        Task<ResponseDto> PostVacancy(PostVacancyRequestDto vacancy);
        Task<ResponseDto> UpdateVacancy(Guid vacancyId, UpdateVacancyRequestDto vacancy);
        Task<ResponseDto> DeactivateVacancy(DeactivateVacancyDto request);
        Task<ApplicantListResponseDTO> ViewVacancyApplicantList(Guid vacancyId);
    }
}
