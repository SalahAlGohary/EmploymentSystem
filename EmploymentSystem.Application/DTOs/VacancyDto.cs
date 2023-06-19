using EmploymentSystem.Application.DTOs.Common;
using EmploymentSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
        public int EmployerId { get; set; }
        public EmployerDto Employer { get; set; }
        public ICollection<ApplicationDto> Applications { get; set; }
    }
}
