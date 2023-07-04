using AutoMapper;
using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.DTOs.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Services
{
    public class BaseService<T> where T : class
    {
        protected IMapper _mapper { get; }
        protected ILogger<T> _logger { get; }

        protected string SerializedResponse = string.Empty;
        protected IApplicationDbContext _context { get; set; }

        protected BaseService(IMapper mapper, ILogger<T> logger, IApplicationDbContext context
        )
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        protected ResponseDto LogException(Exception ex)
        {
            ResponseDto response = new();
            _logger.LogError(ex.Message, ex.StackTrace);
            response.ResponseMessage = "Genera lError";
            SerializedResponse = JsonConvert.SerializeObject(response);
            _logger.LogError(SerializedResponse);
            return response;
        }
    }
}
