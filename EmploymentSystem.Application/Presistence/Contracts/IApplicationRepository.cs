using System;
using System.Collections.Generic;
using System.Text;
using Domain = EmploymentSystem.Domain;

namespace EmploymentSystem.Application.Presistence.Contracts
{
    public interface IApplicationRepository : IGenericRepository<Domain.Application>
    {
    }
}
