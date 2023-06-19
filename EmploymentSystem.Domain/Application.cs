using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Domain
{
    public class Application
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
