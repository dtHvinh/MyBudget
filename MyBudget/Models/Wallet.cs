namespace MyBudget.Models;

public class Wallet
{
    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public decimal Balance { get; private set; }
    public string Currency { get; private set; } = default!;
    public WalletType Type { get; private set; }
    public DateTimeOffset? CreatedDate { get; init; } = DateTimeOffset.UtcNow;

    public ICollection<Transaction> Transactions { get; set; } = default!;

    public Wallet(string name, decimal initialBalance, string currency, WalletType type)
    {
        Name = name;
        Balance = initialBalance;
        Currency = currency;
        Type = type;
    }

    public Wallet()
    {

    }
}

public enum WalletType
{
    Cash,
    BankAccount,
    CreditCard,
    DigitalWallet
}
