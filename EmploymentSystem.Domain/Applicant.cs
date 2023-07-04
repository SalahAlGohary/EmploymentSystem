using EmploymentSystem.Domain.Common;
using EmploymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain
{
    public class Applicant : BaseDomainEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime LastAppliedDate { get; set; }
        public int AppliedVacanciesCount { get; set; }
        public virtual ICollection<VacancyApplication> VacancyApplications { get; set; }
        public UserType UserType { get; } = UserType.Applicant;
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        
    }
}
