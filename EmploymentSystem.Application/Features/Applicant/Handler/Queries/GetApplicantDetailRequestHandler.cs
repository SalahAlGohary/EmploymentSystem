using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Features.Applicant.Request.Queries;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Applicant.Handler.Queries
{
    public class GetApplicantDetailRequestHandler : IRequestHandler<GetApplicantDetailRequest, ApplicantDto>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        public GetApplicantDetailRequestHandler(IApplicantRepository applicantRepository,
            IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;  
        }
        public async Task<ApplicantDto> Handle(GetApplicantDetailRequest request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.GetById(request.Id);
            return _mapper.Map<ApplicantDto>(applicant);
        }
    }
}
