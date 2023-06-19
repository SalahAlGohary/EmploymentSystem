using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Features.Application.Request.Queries;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Application.Handler.Queries
{
    public class GetApplicationDetailRequestHandler : IRequestHandler<GetApplicationDetailRequest, ApplicationDto>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public GetApplicationDetailRequestHandler(IApplicationRepository applicationRepository,
            IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }
        public async Task<ApplicationDto> Handle(GetApplicationDetailRequest request, CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetById(request.Id);
            return _mapper.Map<ApplicationDto>(application);

        }
    }
}
