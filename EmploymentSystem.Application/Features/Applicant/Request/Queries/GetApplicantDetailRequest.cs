using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Applicant.Request.Queries
{
    public class GetApplicantDetailRequest : IRequest<ApplicantDto>
    {
        public Guid Id { get; set; }
    }
}
