using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmploymentAyatem.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Applicant")]
    public class ApplicationController : APIBaseController<ApplicationController>
    {
        private readonly IApplicantService _services;
        public ApplicationController(IApplicantService services)
        {
            _services = services;
        }



        [HttpPost("SearchForVacancy")]
        public async Task<ActionResult<ListOfVacanciesResponseDto>> Search(VacancySearchRequestDto? request)
        {
            return await _services.SearchAsync(request);
        }

        [HttpPost("Apply/{vacancyId}")]
        public async Task<ActionResult<ResponseDto>> Apply(Guid vacancyId)
        {
            var actor = GetActor();
            Guid.TryParse(actor, out Guid applicantId);
            return await _services.SubmitVacancyApplication(applicantId, vacancyId);
        }
    }
}
