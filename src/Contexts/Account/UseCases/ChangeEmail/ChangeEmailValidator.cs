using FluentValidation;

namespace Account.UseCases.ChangeEmail;

public class ChangeEmailValidator : AbstractValidator<ChangeEmailRequest>
{
    public ChangeEmailValidator()
    {
        RuleFor(x => x.accountId).NotEmpty();
        RuleFor(x => x.password).NotEmpty();
        RuleFor(x => x.newEmail).NotEmpty().EmailAddress();
    }
}