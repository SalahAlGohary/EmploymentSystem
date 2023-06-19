using EmploymentSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Domain
{
    public class Application : BaseDomainEntity
    {
        public DateTime ApplicationDate { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
