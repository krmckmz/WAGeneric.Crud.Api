using Crud.Api.Model.Dto;
using FluentValidation;

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
