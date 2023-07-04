using System.Text.Json.Serialization;

namespace EmploymentSystem.Application.DTOs.VacancyDTOs
{
    public class UpdateVacancyRequestDto : VacancyCreateOrUpdateRequestDto
    {
        [JsonIgnore]
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public Guid LastModifiedBy { get; set; }
    }
}
