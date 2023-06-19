using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Features.Vacancy.Requests.Queries;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Handlers.Queries
{
    public class GetVacancyListForEmployerRequestHandler : IRequestHandler<GetVacancyListForEmployerRequest, List<VacancyDto>>
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public GetVacancyListForEmployerRequestHandler(IVacancyRepository vacancyRepository,
            IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }
        public async Task<List<VacancyDto>> Handle(GetVacancyListForEmployerRequest request, CancellationToken cancellationToken)
        {
            var vacancies = await _vacancyRepository.GetAllForEmployerId(request.EmployerId);
            return _mapper.Map<List<VacancyDto>>(vacancies);
    
        }           
    }
}
