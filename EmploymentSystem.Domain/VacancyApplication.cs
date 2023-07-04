using EmploymentSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain
{
    public class VacancyApplication : BaseDomainEntity
    {
        public VacancyApplication(Guid vacancyId,Guid applicantId)
        {
            VacancyId = vacancyId;
            ApplicantId = applicantId;
            ApplicationDate = DateTime.Now;
        }
        public DateTime ApplicationDate { get; set; }
        public Guid ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public Guid VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
