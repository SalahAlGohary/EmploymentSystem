using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs.VacancyDTOs
{
    public class VacancyResponseDto
    {
        public Guid Id { get; set; }
        public string? VacancyNumber { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
