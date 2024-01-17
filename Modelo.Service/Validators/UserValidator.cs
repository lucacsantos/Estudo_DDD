using FluentValidation;
using Modelo.Domain.Entities;

namespace Modelo.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter the name.").NotNull().WithMessage("Please enter the name.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter the email.").NotNull().WithMessage("Please enter the email.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter the password.").NotNull().WithMessage("Please enter the password.");
        }
    }
}
