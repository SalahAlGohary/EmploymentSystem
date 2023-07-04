using EmploymentSystem.Application.DTOs.VacancyDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs.Validators
{
    public class DeactivateRequestValidator : AbstractValidator<DeactivateVacancyDto>
    {
        public DeactivateRequestValidator()
        {
            RuleFor(x => x.VacancyId).NotNull().WithMessage(x => $"{{PropertyName}}: Required")
                .WithMessage(x => $"{{PropertyName}}: Required");

        }
    }
}
