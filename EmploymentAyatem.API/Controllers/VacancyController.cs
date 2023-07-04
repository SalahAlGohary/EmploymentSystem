using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Application.DTOs.IdentityDTOs;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmploymentAyatem.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Employer")]
    public class VacancyController : APIBaseController<VacancyController>
    {
        private readonly IValidator<PostVacancyRequestDto> _requestValidator;
        private readonly IValidator<DeactivateVacancyDto> _deactivateValidator;
        private readonly IEmployerService _employerService;
        public VacancyController(IValidator<LoginRequestDto> loginValidator,
            IValidator<PostVacancyRequestDto> requestValidator,
            IValidator<DeactivateVacancyDto> deactiveValidator,
            IEmployerService employerService)
        {
            _requestValidator = requestValidator;
            _employerService = employerService;
            _deactivateValidator = deactiveValidator;
        }

        [HttpPost("PostVacancy")]
        public async Task<ActionResult<ResponseDto>> CreateNewVacancy(PostVacancyRequestDto request)
        {
            var response = new ResponseDto()
            {
                ResponseMessage = "Failed"
            };
            var actor = GetActor();
            if (!string.IsNullOrEmpty(actor))
            {
                request.CreatedBy = new Guid(actor);
            }
            var validationResult = await _requestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                response.ResponseMessage = string.Join(",", SetErrorMessage(validationResult.Errors));
                return BadRequest(response);
            }

            response = await _employerService.PostVacancy(request);

            return Ok(response);
        }

        [HttpPut("UpdateVacancy/{vacancyId}")]
        public async Task<ActionResult<ResponseDto>> UpdateVacancy(Guid vacancyId, UpdateVacancyRequestDto request)
        {
            var response = new ResponseDto()
            {
                
                ResponseMessage = "Failed"
            };
            var actor = GetActor();
            if (!string.IsNullOrEmpty(actor))
            {
                request.LastModifiedBy =new Guid(actor);
            }

            //if (vacancyId == null)
            //{
            //    response.ResponseCode = ResponseCodes.ValidationError;
            //    response.ResponseMessage = " Vacancy Id is Required field";
            //    return BadRequest(response);
            //}

            response = await _employerService.UpdateVacancy(vacancyId, request);

            return Ok(response);
        }

        [HttpPut("DeactivateVacancy/{vacancyId}")]
        public async Task<ActionResult<ResponseDto>> DeactivateVacancy(Guid vacancyId)
        {
            var response = new ResponseDto()
            {
                ResponseMessage = "Failed"
            };
            DeactivateVacancyDto request = new DeactivateVacancyDto();
            request.VacancyId = vacancyId;
            var actor = GetActor();
            if (!string.IsNullOrEmpty(actor))
            {
                request.EmployerId = new Guid(actor);
            }
            var validationResult = await _deactivateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                response.ResponseMessage = string.Join(",", SetErrorMessage(validationResult.Errors));
                return BadRequest(response);
            }

            response = await _employerService.DeactivateVacancy(request);

            return Ok(response);
        }


        [HttpGet("GetApplicantsForVacancy/{vacancyId}")]
        public async Task<ActionResult<ApplicantListResponseDTO>> GetAllApplicantsForVacancy(Guid vacancyId)
        {
            var response = new ApplicantListResponseDTO()
            {
                ResponseMessage = "Failed"
            };

            //if (vacancyId == 0)
            //{
               
            //    response.ResponseMessage = " Vacancy Id is Required field";
            //    return BadRequest(response);
            //}

            response = await _employerService.ViewVacancyApplicantList(vacancyId);

            return Ok(response);
        }
    }
}
