using EmploymentSystem.Application.DTOs.IdentityDTOs;
using EmploymentSystem.Application.Utilities;
using FluentValidation;


namespace EmploymentSystem.Application.DTOs.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .Matches(RegularExpressions.Email).WithMessage(x => $"{{PropertyName}}: Not Valid Email");
        }
    }

}
