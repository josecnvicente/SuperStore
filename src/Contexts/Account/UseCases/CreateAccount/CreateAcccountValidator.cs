using FluentValidation;

namespace Account.UseCases.CreateAccount;

public sealed class CreateAcccountValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAcccountValidator()
    {
        RuleFor(x => x.Username).NotEmpty().Length(6, 25);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().Length(8, 20);
        RuleFor(x => x.FullName).NotEmpty().Length(3, 20);
        RuleFor(x => x.BirthDate).Must(ValidAge).WithMessage("Você precisa ter 18 anos ou mais.");
    }

    private bool ValidAge(DateOnly date)
    {
        int age = DateTime.Now.Year - date.Year;
        if (age < 18)
            return false;
        return true;
    }
}