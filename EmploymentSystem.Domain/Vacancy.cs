using EmploymentSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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
        public Employer Employer { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
