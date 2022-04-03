using FluentValidation;

namespace Crud.Api
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
