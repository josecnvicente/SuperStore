using Account.Entities;
using Account.UseCases.CreateAccount.Contracts;
using FluentValidation.Results;
using MediatR;

namespace Account.UseCases.CreateAccount;

public class CreateAccountHandler(IRepository repository) : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        CreateAcccountValidator validator = new CreateAcccountValidator();

        ValidationResult validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            return new CreateAccountResponse(Message: String.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage)));

        UserAccount user = request;

        if (repository.VerifyIfExists(user))
            return new CreateAccountResponse(Message: "Usuário já existe.");

        repository.Create(user);

        return new CreateAccountResponse(Message: "Conta criada com sucesso.");
    }
}
