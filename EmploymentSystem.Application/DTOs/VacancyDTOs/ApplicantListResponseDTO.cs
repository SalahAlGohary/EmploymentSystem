using EmploymentSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs.VacancyDTOs
{
    public class ApplicantListResponseDTO : ResponseDto
    {
        public IEnumerable<ApplicantDto>? Applicants { get; set; }
    }
}
