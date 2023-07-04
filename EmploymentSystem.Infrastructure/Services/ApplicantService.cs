using AutoMapper;
using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Application.DTOs.VacancyDTOs;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EmploymentSystem.Domain;

namespace EmploymentSystem.Infrastructure.Services
{
    public class ApplicantService : BaseService<ApplicantService>, IApplicantService
    {
        public ApplicantService(IMapper mapper,
        ILogger<ApplicantService> logger,
        IApplicationDbContext context) : base(mapper, logger, context)
        {
        }

        public async Task<ListOfVacanciesResponseDto> SearchAsync(VacancySearchRequestDto searchRequest)
        {
            var response = new ListOfVacanciesResponseDto()
            {
                ResponseMessage = "Not Found"
            };
            try
            {
                var vacanciesList = await _context.Vacancies
                    .Where(x => x.IsActive && (!string.IsNullOrWhiteSpace(searchRequest.Title) ? x.Title.Equals(searchRequest.Title) : true))
                    .ToListAsync();

                if (vacanciesList.Any())
                {
                    response.ResponseMessage = "Success";
                 
                    response.Vacancies = _mapper.Map<IEnumerable<VacancyResponseDto>>(vacanciesList);
                }
            }
            catch (Exception ex)
            {
                return (ListOfVacanciesResponseDto)LogException(ex);
            }
            return response;
        }

        public async Task<ResponseDto> SubmitVacancyApplication(Guid applicantId, Guid vacancyId)
        {
            var response = new ResponseDto()
            {
                ResponseMessage = "Failed"
            };
            await using var transaction = await _context.Transaction;
            try
            {

                if (!await HasAppliedToday(applicantId))
                {
                    var application = new VacancyApplication(vacancyId,applicantId);
                    application.ApplicantId = applicantId;
                    var added = _context.VacancyApplications.Add(application);
                    if (added.State != EntityState.Added)
                    {
                        await transaction.RollbackAsync();
                        return response;
                    }
                    await _context.SaveChangesAsync(default);

                    return await UpdateLastAppliedDateForApplicant(applicantId, transaction);
                }
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return LogException(ex);
            }

            return response;
        }

        private async Task<ResponseDto> UpdateLastAppliedDateForApplicant(Guid applicantId, IDbContextTransaction transaction)
        {
            var response = new ResponseDto()
            {
                ResponseMessage = "Failed"
            };
            try
            {
                var applicant = await _context.Applicants.FirstOrDefaultAsync(ap=>ap.Id == applicantId);    
                if (applicant != null)
                {
                    applicant.LastAppliedDate = DateTime.Now;
                    applicant.AppliedVacanciesCount++;
                    var updated = _context.Applicants.Update(applicant);
                    if (updated.State == EntityState.Modified)
                    {
                        await _context.SaveChangesAsync(default);
                        response.ResponseMessage = "Success";
                        await transaction.CommitAsync();
                        return response;
                    }
                }
                await transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return LogException(ex);
            }
            return response;
        }
        private async Task<bool> HasAppliedToday(Guid applicantId)
        {
            var hasAppliedToday = await  _context.Applicants
                .Where(ap => ap.Id == applicantId && ap.LastAppliedDate > DateTime.Now.AddDays(-1)).FirstOrDefaultAsync();
            if (hasAppliedToday != null)
            {
                return true;
            }

            return false;
        }
    }
}
