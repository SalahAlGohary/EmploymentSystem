﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain = EmploymentSystem.Domain;

namespace EmploymentSystem.Application.Presistence.Contracts
{
    public interface IApplicationRepository : IGenericRepository<Domain.Application>
    {
        Task<IReadOnlyList<Domain.Application>> GetAllForVacancyId(Guid Id);
    }
}
