using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.DTOs
{
    public class ApplicationDto : BaseDto
    {
        public DateTime ApplicationDate { get; set; }
        public Guid ApplicantId { get; set; }
        public ApplicantDto Applicant { get; set; }
        public Guid VacancyId { get; set; }
        public VacancyDto Vacancy { get; set; }

    }
}
