using EmploymentSystem.Application.DTOs.VacancyDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.DTOs.Validators
{
    public class VacancyRequestValidator : AbstractValidator<PostVacancyRequestDto>
    {
        public VacancyRequestValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage(x => $"{{PropertyName}}: Required");


            RuleFor(x => x.Title)
                .NotNull().WithMessage(x => $"{{PropertyName}}: Required");

        }
    }
}
