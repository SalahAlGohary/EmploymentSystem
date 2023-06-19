using AutoMapper;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Application.Features.Employer.Request;
using EmploymentSystem.Application.Presistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Employer.Handler.Queries
{
    public class GetEmployerDetailRequestHandler : IRequestHandler<GetEmployerDetailRequest, EmployerDto>
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IMapper _mapper;

        public GetEmployerDetailRequestHandler(IEmployerRepository employerRepository,
            IMapper mapper)
        {
            _employerRepository = employerRepository;
            _mapper = mapper; 
        }
        public async Task<EmployerDto> Handle(GetEmployerDetailRequest request, CancellationToken cancellationToken)
        {
            var employer = await _employerRepository.GetById(request.Id);
            return _mapper.Map<EmployerDto>(employer);

        }
    }
}
