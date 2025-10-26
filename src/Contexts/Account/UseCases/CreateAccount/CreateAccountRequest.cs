using MediatR;

namespace Account.UseCases.CreateAccount;

public sealed record CreateAccountRequest(string Username, string FullName, string Password, string Email, DateOnly BirthDate)
    : IRequest<CreateAccountResponse>;
