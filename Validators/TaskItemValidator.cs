using FluentValidation;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Validators
{
    /// <summary>
    /// Some Validation On Tasks
    /// </summary>
    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Task Name is required.")
                .MaximumLength(100).WithMessage("Task Name cannot exceed 100 characters.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Task status is required.");
        }
    }

}
