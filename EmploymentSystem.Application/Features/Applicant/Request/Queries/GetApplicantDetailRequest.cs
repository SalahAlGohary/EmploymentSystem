using EmploymentSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentSystem.Application.Features.Applicant.Request.Queries
{
    public class GetApplicantDetailReuest : IRequest<ApplicantDto>
    {
        public Guid Id { get; set; }
    }
}
