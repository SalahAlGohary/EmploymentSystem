using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Vacancy.Requests
{
    public class GetVacancyRequest : IRequest<List<VacancyDto>>
    {

    }
}
