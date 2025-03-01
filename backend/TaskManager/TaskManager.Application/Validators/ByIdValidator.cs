using FluentValidation;

namespace TaskManager.Application.Validators
{
    public class ByIdValidator : AbstractValidator<Guid>
    {
        public ByIdValidator()
        {
            RuleFor(id => id)
                .NotEmpty().WithMessage("El ID es obligatorio.");
        }

    }
}
