using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Employer.Request.Commands
{
    public class CreateEmployerRequest : IRequest<Guid>
    {
        public EmployerDto EmployerDto { get; set; }    

    }
}
