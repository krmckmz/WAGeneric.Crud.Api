using FluentValidation;

namespace Crud.Api
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
