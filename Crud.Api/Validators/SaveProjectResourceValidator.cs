using Crud.Api.Model.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Validators
{
    public class SaveProjectResourceValidator:AbstractValidator<SaveProjectDto>
    {
        public SaveProjectResourceValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
