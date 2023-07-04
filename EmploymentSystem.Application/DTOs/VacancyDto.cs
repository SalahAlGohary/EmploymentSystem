using EmploymentSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs
{
    public class VacancyDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaximumApplications { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public Guid EmployerId { get; set; }
        public EmployerDto Employer { get; set; }
        public ICollection<VacancyApplicationDto> Applications { get; set; }
    }
}
