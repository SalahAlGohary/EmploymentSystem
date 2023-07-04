using EmploymentSystem.Application.DTOs.IdentityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts
{
    public interface IIdentityService
    {
        Task<RegisterResponseDto> RegisterUser(RegisterRequestDto request);
        Task<LoginResponseDto> Login(LoginRequestDto request);
    }
}
