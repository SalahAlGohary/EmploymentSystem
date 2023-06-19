using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Domain
{
    public class Employer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
