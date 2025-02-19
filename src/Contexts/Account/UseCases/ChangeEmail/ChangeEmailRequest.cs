using MediatR;

namespace Account.UseCases.ChangeEmail;

public sealed record ChangeEmailRequest(Guid accountId, string password, string newEmail) :
    IRequest<ChangeEmailResponse>;