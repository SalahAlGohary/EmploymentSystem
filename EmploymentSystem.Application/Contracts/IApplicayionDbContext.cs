using EmploymentSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts
{
    public interface IApplicationDbContext 
    {

        DbSet<User> Users { get; }
        DbSet<UserRole> UserRoles { get; }
        DbSet<Vacancy> Vacancies { get; }
        DbSet<Employer> Employers { get; }
        DbSet<VacancyApplication> VacancyApplications { get; }
        DbSet<Applicant> Applicants { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> Transaction { get; }
    }
}
