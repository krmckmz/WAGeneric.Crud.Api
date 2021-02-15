using Crud.Api.Model.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Validators
{
    public class SavePluginResourceValidator:AbstractValidator<SavePluginDto>
    {
        public SavePluginResourceValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(a => a.ProjectId)
                .NotEmpty()
                .WithMessage("'ProjectId' must not be empty.");
        }
    }
}
