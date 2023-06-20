using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Vacancy.Requests.Commands
{
    public class CreateVacancyRequest : IRequest<Guid>
    {
        public VacancyDto VacancyDto { get; set; }
    }
}
