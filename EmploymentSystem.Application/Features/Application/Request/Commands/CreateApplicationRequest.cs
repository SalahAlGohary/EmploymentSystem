using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Application.Request.Commands
{
    public class CreateApplicationRequest : IRequest<Guid>
    {
        public ApplicationDto ApplicationDto { get; set; }
    }
}
