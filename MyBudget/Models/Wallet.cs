namespace MyBudget.Models;

public class Wallet
{
    public int Id { get; private set; }
    public string Name { get; set; } = default!;
    public decimal Balance { get; set; }
    public string Currency { get; set; } = default!;
    public WalletType Type { get; set; }
    public DateTimeOffset CreatedDate { get; init; } = DateTimeOffset.UtcNow;

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

    public void UpdateWallet(string name, decimal balance, string currency, WalletType type)
    {
        Name = name;
        Balance = balance;
        Currency = currency;
        Type = type;
    }
}

public enum WalletType
{
    Cash,
    BankAccount,
    CreditCard,
    DigitalWallet
}
