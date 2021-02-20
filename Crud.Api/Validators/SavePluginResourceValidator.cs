using Crud.Api.Model.Dto;
using FluentValidation;

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
