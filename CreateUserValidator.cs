using FluentValidation;

namespace PipelineBehavior
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).Length(4, 16);
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email address is invalid");
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords must match");
        }
    }
}
