using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EmploymentSystem.Application.Features.Vacancy.Requests.Queries;

namespace EmploymentSystem.Application.Features.Vacancy.Handlers.Queries
{
    public class GetVacancyDetailRequestHandler : IRequestHandler<GetVacancyDetailRequest, VacancyDto>
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public GetVacancyDetailRequestHandler(IVacancyRepository vacancyRepository,
            IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }
        public async Task<VacancyDto> Handle(GetVacancyDetailRequest request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepository.GetById(request.Id);
            return _mapper.Map<VacancyDto>(vacancy);

        }
    }
}
