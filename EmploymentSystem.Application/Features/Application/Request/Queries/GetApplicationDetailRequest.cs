using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Application.Request.Queries
{
    public class GetApplicationDetailRequest : IRequest<ApplicationDto>
    {
        public Guid Id { get; set; }
    }
}
