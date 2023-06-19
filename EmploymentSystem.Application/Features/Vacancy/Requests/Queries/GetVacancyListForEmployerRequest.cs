using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Vacancy.Requests.Queries
{
    public class GetVacancyListForEmployerRequest : IRequest<List<VacancyDto>>
    {
        public Guid EmployerId { get; set; }
    }
}
