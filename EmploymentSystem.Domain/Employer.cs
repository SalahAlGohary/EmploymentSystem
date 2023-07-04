using EmploymentSystem.Domain.Common;
using EmploymentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain
{
    public class Employer : BaseDomainEntity
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public  virtual ICollection<Vacancy> Vacancies { get; set; }
        public UserType UserType { get; } = UserType.Employer;
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
