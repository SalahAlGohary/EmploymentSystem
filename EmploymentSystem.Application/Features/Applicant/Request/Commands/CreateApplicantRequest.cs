using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Applicant.Request.Commands
{
    public class CreateApplicantRequest : IRequest<Guid>
    {
        public ApplicantDto ApplicantDto { get; set; }
    }
}
