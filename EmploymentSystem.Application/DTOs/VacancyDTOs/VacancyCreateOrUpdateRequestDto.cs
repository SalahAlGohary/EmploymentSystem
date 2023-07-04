namespace EmploymentSystem.Application.DTOs.VacancyDTOs
{
    public class VacancyCreateOrUpdateRequestDto
    {
        public string? Title { get; set; }
        public string? VacancyNumber { get; set; }
        public int MaxApplications { get; set; } = 15;
        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
