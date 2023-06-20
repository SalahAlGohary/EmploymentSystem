using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Employer.Request.Queries
{
    public class GetEmployerDetailRequest : IRequest<EmployerDto>
    {
        public Guid Id { get; set; }
    }
}
