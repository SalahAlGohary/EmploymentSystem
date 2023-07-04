using System.Text.Json.Serialization;

namespace EmploymentSystem.Application.DTOs.VacancyDTOs
{
    public class PostVacancyRequestDto : VacancyCreateOrUpdateRequestDto
    {
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        
    }
}
