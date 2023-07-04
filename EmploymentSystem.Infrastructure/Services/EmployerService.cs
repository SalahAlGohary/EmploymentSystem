using AutoMapper;
using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using EmploymentSystem.Domain;
using EmploymentSystem.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Services
{
    public class EmployerService : BaseService<EmployerService>, IEmployerService
    {
        public EmployerService(IMapper mapper,
            ILogger<EmployerService> logger,
            ApplicationDbContext context) : base(mapper, logger, context)
        {
        }
        public async Task<ResponseDto> PostVacancy(PostVacancyRequestDto vacancyRequest)
        {
            var response = new ResponseDto()
            {
                ResponseMessage = "Failed"
            };
            try
            {
                var vacancy = _mapper.Map<Vacancy>(vacancyRequest);
                var result = await _context.Vacancies.AddAsync(vacancy);
                if (result.State != EntityState.Added)
                {
                    _logger.LogError(result.State.ToString());
                    return response;
                }
                await _context.SaveChangesAsync(default);
                response.ResponseMessage = "Success";
            }
            catch (Exception ex)
            {
                return LogException(ex);
            }
            return response;
        }
        public async Task<ResponseDto> UpdateVacancy(Guid vacancyId, UpdateVacancyRequestDto vacancy)
        {
            var response = new ResponseDto()
            {
                ResponseMessage = "Failed"
            };
            try
            {
                var affectedRows = 0;
                var vacancyEntity = await _context.Vacancies.Where(v => v.Id == vacancyId).FirstOrDefaultAsync();
                if (vacancyEntity != null)
                {
                    _mapper.Map(vacancy, vacancyEntity);
                    affectedRows = await _context.SaveChangesAsync(default);
                }

                if (affectedRows != 0)
                {
                    response.ResponseMessage = "Success";
                }
            }
            catch (Exception ex)
            {
                return LogException(ex);
            }
            return response;
        }
        public async Task<ResponseDto> DeactivateVacancy(DeactivateVacancyDto request)
        {
            var response = new ResponseDto()
            {
                ResponseMessage = "Failed"
            };
            try
            {
                var vacancyEntity = await _context.Vacancies.Where(v => v.Id == request.VacancyId).FirstOrDefaultAsync();
                if (vacancyEntity != null)
                {
                    vacancyEntity.IsActive = false;
                    vacancyEntity.LastModifiedBy = request.EmployerId;
                    vacancyEntity.LastModifiedAt = DateTime.Now;

                    var affectedRows = await _context.SaveChangesAsync(default);
                    if (affectedRows != 0)
                    {  
                        response.ResponseMessage = "Success";
                    }

                    return response;
                }
                response.ResponseMessage = "Not Found";

            }
            catch (Exception ex)
            {
                return LogException(ex);
            }
            return response;
        }
        public async Task<ApplicantListResponseDTO> ViewVacancyApplicantList(Guid vacancyId)
        {
            var response = new ApplicantListResponseDTO()
            {
                ResponseMessage = "Not Found"
            };

            try
            {
                var applicantList = await _context.VacancyApplications.Where(v => v.VacancyId == vacancyId).Select(x=>x.Applicant).ToListAsync();

                if (!applicantList.Any())
                {
                    response.ResponseMessage = "Not Found";
                    return response;
                }

                response.ResponseMessage = "Success";  
                response.Applicants = _mapper.Map<IEnumerable<ApplicantDto>>(applicantList);
            }
            catch (Exception ex)
            {
                return (ApplicantListResponseDTO)LogException(ex);
            }
            return response;
        }

    }
}
