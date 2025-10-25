using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models;

public class Wallet
{
    public int Id { get; private set; }
    public string Name { get; set; } = default!;
    public decimal Balance { get; set; }
    public string Currency { get; set; } = default!;
    public DateTimeOffset CreatedDate { get; init; } = DateTimeOffset.UtcNow;

    [ForeignKey(nameof(WalletType))]
    public int WalletTypeId { get; set; }
    public WalletType WalletType { get; set; } = default!;

    public ICollection<Transaction> Transactions { get; set; } = default!;

    public Wallet(string name, decimal initialBalance, string currency)
    {
        Name = name;
        Balance = initialBalance;
        Currency = currency;
    }

    public Wallet()
    {

    }

    public void UpdateWallet(string name, decimal balance, string currency, WalletType type)
    {
        Name = name;
        Balance = balance;
        Currency = currency;
        WalletType = type;
    }
}

