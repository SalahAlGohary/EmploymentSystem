using EmploymentSystem.Application.DTOs.IdentityDTOs;
using EmploymentSystem.Application.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage(x => $"{{PropertyName}}: Not Valid Email")
              .Matches(RegularExpressions.Email).WithMessage(x => $"{{PropertyName}}: Not Valid Email");

            RuleFor(x => x.MobileNumber)
                .MinimumLength(11).WithMessage(x => $"{{PropertyName}}: Min Length Is11")
                .MaximumLength(15).WithMessage(x => $"{{PropertyName}}: Max Length Is 15")
                .Matches(RegularExpressions.MobileNumber).WithMessage(x => $"{{PropertyName}}: Invalid Mobile Number");

            RuleFor(x => x.Password).MinimumLength(8).WithMessage(x => $"{{PropertyName}}: Password Min Lentgh")
                .Matches(RegularExpressions.Password).WithMessage(x => $"{{PropertyName}}: Invalid Password");

            RuleFor(x => x.FirstName).NotNull().WithMessage(x => $"{{PropertyName}}: Required");
            RuleFor(x => x.LastName).NotNull().WithMessage(x => $"{{PropertyName}}: Required");


        }
    }
}
