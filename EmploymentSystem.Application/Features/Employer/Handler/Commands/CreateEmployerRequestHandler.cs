using AutoMapper;
using EmploymentSystem.Application.Features.Employer.Request.Commands;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Employer.Handler.Commands
{
    public class CreateEmployerRequestHandler : IRequestHandler<CreateEmployerRequest, Guid>
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IMapper _mapper;

        public CreateEmployerRequestHandler(IEmployerRepository employerRepository,
            IMapper mapper)
        {
            _employerRepository = employerRepository;
            _mapper = mapper;
                
        }
        public async Task<Guid> Handle(CreateEmployerRequest request, CancellationToken cancellationToken)
        {
            var employer = _mapper.Map<Domain.Employer>(request.EmployerDto);
            employer = await _employerRepository.Add(employer);
            return employer.Id;
        }
    }
}
