using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Vacancy.Requests
{
    public class GetVacancyDetailRequest : IRequest<VacancyDto>
    {
        public int Id { get; set; }
    }
}
