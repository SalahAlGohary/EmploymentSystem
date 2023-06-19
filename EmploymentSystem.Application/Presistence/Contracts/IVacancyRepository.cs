using EmploymentSystem.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Presistence.Contracts
{
    public interface IVacancyRepository : IGenericRepository<Vacancy>
    {
        Task<IReadOnlyList<Vacancy>> GetAllForEmployerId(Guid Id);
    }
}
