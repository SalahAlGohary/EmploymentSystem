using AutoMapper;
using EmploymentSystem.Application.Features.Application.Request.Commands;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Application.Handler.Commands
{
    public class CreateApplicationRequestHandler : IRequestHandler<CreateApplicationRequest, Guid>  
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public CreateApplicationRequestHandler(IApplicationRepository applicationRepository,
            IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateApplicationRequest request, CancellationToken cancellationToken)
        {
            var application = _mapper.Map<Domain.Application>(request.ApplicationDto);
            application = await _applicationRepository.Add(application);
            return application.Id;

        }
    }
}
