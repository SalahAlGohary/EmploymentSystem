using EmploymentSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs
{
    public class ApplicantDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime LastAppliedDate { get; set; }
        public int AppliedVacanciesCount { get; set; }
    }
}
