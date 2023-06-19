using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Features.Vacancy.Requests;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Handlers.Queries
{
    public class GetVacancyListRequestHandler : IRequestHandler<GetVacancyListRequest, List<VacancyDto>>
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public GetVacancyListRequestHandler(IVacancyRepository vacancyRepository,
            IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }
        public async Task<List<VacancyDto>> Handle(GetVacancyListRequest request, CancellationToken cancellationToken)
        {
            var vacancies = await _vacancyRepository.GetAll();
            return _mapper.Map<List<VacancyDto>>(vacancies);
    
        }           
    }
}
