using AutoMapper;
using EmploymentSystem.Application.Features.Applicant.Request.Commands;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Applicant.Handler.Commands
{
    public class CreateApplicantRequestHandler : IRequestHandler<CreateApplicantRequest, Guid>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;

        public CreateApplicantRequestHandler(IApplicantRepository applicantRepository,
            IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateApplicantRequest request, CancellationToken cancellationToken)
        {
            var applicant = _mapper.Map<Domain.Applicant>(request.ApplicantDto);
            applicant = await _applicantRepository.Add(applicant);
            return applicant.Id;
        }
    }
}
