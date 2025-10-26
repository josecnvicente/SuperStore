using Account.UseCases.CreateAccount;

namespace Account.Entities;

public sealed class UserAccount
{
    public Guid Id { get; set; } = default;
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? DeletedAt { get; set; } = null;
    public bool IsActive { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

    public static implicit operator UserAccount(CreateAccountRequest request)
        => new()
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            FullName = request.FullName,
            Password = request.Password,
            Email = request.Email,
            BirthDate = request.BirthDate,
            CreatedAt = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        };
}
