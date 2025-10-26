using Account.UseCases.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace AccountAPI.EndPoints;

[ExcludeFromCodeCoverage]
public static class Account
{
    public static void MapAccountEndPoints(this WebApplication app)
    {
        app.MapPost("api/createaccount", async ([FromServices]IMediator mediator, [FromBody]CreateAccountRequest request) =>
        {
            var response = await mediator.Send(request);
            return response;
        });
    }
}
