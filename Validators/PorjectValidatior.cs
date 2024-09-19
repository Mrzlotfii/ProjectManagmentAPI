using FluentValidation;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Validators
{
    /// <summary>
    /// Some Validation On Projects
    /// </summary>
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Project Name is required.")
                .MaximumLength(100).WithMessage("Project Name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleForEach(x => x.Tasks).SetValidator(new TaskItemValidator());
        }
    }
}
