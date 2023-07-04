using EmploymentSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain
{
    public class Vacancy : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaximumApplications { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public Guid EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual ICollection<VacancyApplication> VacancyApplications { get; set; }
    }
}
