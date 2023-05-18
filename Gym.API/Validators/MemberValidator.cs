using FluentValidation;
using Gym.API.Application.Commands.MemberCommands;

namespace Gym.API.Validators
{
    public class MemberValidator : AbstractValidator<CreateMemberCommand>
    {
        public MemberValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required")
                .MaximumLength(150).WithMessage("Name must be less than 150 characters.");

            RuleFor(m => m.Age).NotEmpty().WithMessage("Age is required");

            RuleFor(m => m.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Must be a valid email address");

            RuleFor(m => m.Plan).NotEmpty().WithMessage("Plan must be declared");

            RuleFor(m => m.Subscription).NotEmpty().WithMessage("Subscription must be declared");

        }
    }
}
