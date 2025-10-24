using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models;

public class Transaction
{
    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public string? Note { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public TransactionType Type { get; private set; }

    [ForeignKey(nameof(Wallet))] public int WalletId { get; set; }
    public Wallet Wallet { get; set; } = default!;

    [ForeignKey(nameof(Category))] public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;

    public Transaction()
    {

    }

    public Transaction(decimal amount, string? note, TransactionType type)
    {
        Amount = amount;
        Note = note;
        Type = type;
    }
}

public enum TransactionType
{
    Income,
    Expense,
    Transfer
}