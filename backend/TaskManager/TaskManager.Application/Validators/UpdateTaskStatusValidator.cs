using FluentValidation;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Validators
{
    public class UpdateTaskStatusValidator : AbstractValidator<(Guid Id, UpdateTaskStatusDTO Task)>
    {
        public UpdateTaskStatusValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El ID de la tarea es obligatorio.");

            RuleFor(x => x.Task.IsCompleted)
                .NotNull().WithMessage("El estado de la tarea es obligatorio.");
        }
    }
}
