using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models;

public class Wallet(string name, decimal initialBalance, string currency, WalletType type)
{
    public int Id { get; private set; }
    public string Name { get; private set; } = name;
    public decimal Balance { get; private set; } = initialBalance;
    public string Currency { get; private set; } = currency;
    public WalletType Type { get; private set; } = type;
    public DateTimeOffset? CreatedDate { get; init; } = DateTimeOffset.UtcNow;

    [ForeignKey(nameof(User))] public int UserId { get; set; }
    public User User { get; set; } = default!;
}

public enum WalletType
{
    Cash,
    BankAccount,
    CreditCard,
    DigitalWallet
}
