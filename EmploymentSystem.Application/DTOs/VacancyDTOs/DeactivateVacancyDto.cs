using System.Text.Json.Serialization;

namespace EmploymentSystem.Application.DTOs.VacancyDTOs
{
    public class DeactivateVacancyDto
    {
        public Guid VacancyId { get; set; }
        public Guid EmployerId { get; set; }
    }
}
