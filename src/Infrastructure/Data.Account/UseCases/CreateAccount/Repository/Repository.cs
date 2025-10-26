using Account.Entities;
using Account.UseCases.CreateAccount.Contracts;
using Data.Account.Context;
using System.Diagnostics.CodeAnalysis;

namespace Data.Account.UseCases.CreateAccount.Repository;

[ExcludeFromCodeCoverage]
public class Repository : IRepository
{
    public int Create(UserAccount request)
    {
        using AccountContext context = new();

        context.Accounts.Add(request);

        return context.SaveChanges();
    }

    public bool VerifyIfExists(UserAccount request)
    {
        using AccountContext context = new();

        return context.Accounts.Any(_users => _users.Email == request.Email || _users.FullName == request.FullName);
    }
}
