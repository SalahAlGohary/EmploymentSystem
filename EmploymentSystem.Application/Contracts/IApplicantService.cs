using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts
{
    public interface IApplicantService
    {
        Task<ListOfVacanciesResponseDto> SearchAsync(VacancySearchRequestDto searchRequestDto);
        Task<ResponseDto> SubmitVacancyApplication(Guid applicantId, Guid vacancyId);
    }
}
