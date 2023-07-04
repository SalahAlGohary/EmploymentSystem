using EmploymentSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs
{
    public class VacancyApplicationDto : BaseDto
    {
        public DateTime ApplicationDate { get; set; }
        public Guid ApplicantId { get; set; }
        public ApplicantDto Applicant { get; set; }
        public Guid VacancyId { get; set; }
        public VacancyDto Vacancy { get; set; }

    }
}
