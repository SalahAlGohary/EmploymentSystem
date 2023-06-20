using AutoMapper;
using EmploymentSystem.Application.Features.Vacancy.Requests.Commands;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace EmploymentSystem.Application.Features.Vacancy.Handlers.Commands
{
    public class CreateVacancyRequestHandler : IRequestHandler<CreateVacancyRequest, Guid>
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public CreateVacancyRequestHandler(IVacancyRepository vacancyRepository,
            IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;

        }
        public async Task<Guid> Handle(CreateVacancyRequest request, CancellationToken cancellationToken)
        {
            var vacancy = _mapper.Map<Domain.Vacancy>(request.VacancyDto);
            vacancy = await _vacancyRepository.Add(vacancy);
            return vacancy.Id;
        }
    }
}
