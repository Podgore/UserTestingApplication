using FluentValidation;
using UserTestingApp.Common.DTO;

namespace UserTestingApp.Validators.UserValidator;

public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(dto => dto.Email)
           .NotEmpty()
           .EmailAddress()
           .WithMessage("Your email is invalid");
    }
}
