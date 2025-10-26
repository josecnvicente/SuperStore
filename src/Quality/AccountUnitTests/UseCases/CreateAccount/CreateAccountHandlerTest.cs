using Account.Entities;
using Account.UseCases.CreateAccount;
using Account.UseCases.CreateAccount.Contracts;
using Moq;

namespace AccountUnitTests.UseCases.CreateAccount;

public class CreateAccountHandlerTest
{
    private Mock<IRepository> _repository = new();

    [Fact]
    public void CriarContaComSucesso()
    {
        var request = new CreateAccountRequest(
            Username: "josezinho123",
            FullName: "José",
            Password: "12345678",
            Email: "josezinho123@gmail.com",
            BirthDate: DateOnly.FromDateTime(DateTime.Now.AddYears(-29))
        );

        _repository.Setup(x => x.VerifyIfExists(It.IsAny<UserAccount>())).Returns(false);

        _repository.Setup(x => x.Create(It.IsAny<UserAccount>())).Returns(1);

        CreateAccountHandler handler = new(_repository.Object);

        var response = Task.Run(() => handler.Handle(request, default));

        Assert.True(response.Result.Message == "Conta criada com sucesso.");
    }

    [Fact]
    public void CriarContaComParametrosInvalidos()
    {
        var request = new CreateAccountRequest(
            Username: "jos",
            FullName: "Jo",
            Password: "1234567",
            Email: "josezinho123",
            BirthDate: DateOnly.FromDateTime(DateTime.Now)
        );

        CreateAccountHandler handler = new(_repository.Object);

        var response = Task.Run(() => handler.Handle(request, default));

        Assert.True(response.Result.Message == "'Username' deve ter entre 6 e 25 caracteres. Você digitou 3 caracteres., 'Email' é um endereço de email inválido., 'Password' deve ter entre 8 e 20 caracteres. Você digitou 7 caracteres., 'Full Name' deve ter entre 3 e 20 caracteres. Você digitou 2 caracteres., Você precisa ter 18 anos ou mais.");
    }

    [Fact]
    public void CriarContaComEmailJaExistente()
    {
        var request = new CreateAccountRequest(
            Username: "josezinho123",
            FullName: "José",
            Password: "12345678",
            Email: "josezinho123@gmail.com",
            BirthDate: DateOnly.FromDateTime(DateTime.Now.AddYears(-29))
        );

        _repository.Setup(x => x.VerifyIfExists(It.IsAny<UserAccount>())).Returns(true);

        CreateAccountHandler handler = new(_repository.Object);

        var response = Task.Run(() => handler.Handle(request, default));

        Assert.True(response.Result.Message == "Usuário já existe.");
    }
}