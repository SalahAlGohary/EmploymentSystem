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
    public class GetApplicationListForVacancyRequestHandler : IRequestHandler<GetApplicationListForVacancyRequest, List<ApplicationDto>>    
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public GetApplicationListForVacancyRequestHandler(IApplicationRepository applicationRepository,
            IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;     
        }
        public async Task<List<ApplicationDto>> Handle(GetApplicationListForVacancyRequest request, CancellationToken cancellationToken)
        {
            var applications = await _applicationRepository.GetAllForVacancyId(request.VacancyId);
            return _mapper.Map<List<ApplicationDto>>(applications);

        }
    }
}
