using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset Date { get; set; }
    public TransactionType Type { get; set; }

    [ForeignKey(nameof(Wallet))] public int WalletId { get; set; }
    public Wallet Wallet { get; set; } = default!;

    [ForeignKey(nameof(Category))] public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}

public enum TransactionType
{
    Income,
    Expense,
    Transfer
}