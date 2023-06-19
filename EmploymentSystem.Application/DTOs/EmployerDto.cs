using EmploymentSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.DTOs
{
    public class EmployerDto
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<VacancyDto> Vacancies { get; set; }
    }
}
