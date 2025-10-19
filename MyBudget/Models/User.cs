using Microsoft.AspNetCore.Identity;

namespace MyBudget.Models;

public class User
{
    private static readonly PasswordHasher<User> _hasher = new();

    public int Id { get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string? Email { get; set; }
    public DateTimeOffset? CreatedDate { get; init; }
    public DateTimeOffset? LastModifiedDate { get; private set; }

    public ICollection<Wallet> Wallets { get; set; } = default!;
    public ICollection<Category> Categories { get; set; } = default!;

    public User(string username, string password, string email)
    {
        UserName = username;
        PasswordHash = _hasher.HashPassword(this, password);
        Email = email;
        CreatedDate = DateTimeOffset.UtcNow;
    }

    public void UpdatePassword(string newPassword)
    {
        PasswordHash = _hasher.HashPassword(this, newPassword);
        LastModifiedDate = DateTimeOffset.UtcNow;
    }

    public void UpdateEmail(string newEmail)
    {
        Email = newEmail;
        LastModifiedDate = DateTimeOffset.UtcNow;
    }

    public bool VerifyPassword(string password)
    {
        var result = _hasher.VerifyHashedPassword(this, PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }
}
