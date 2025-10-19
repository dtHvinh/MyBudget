using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models;

public class Category(string name, string description, CategoryType type, string? icon = null)
{
    public int Id { get; private set; }
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public string? Icon { get; private set; } = icon;
    public CategoryType Type { get; private set; } = type;

    [ForeignKey(nameof(User))] public int? UserId { get; set; }
    public User User { get; set; } = default!;

    public ICollection<Transaction> Transactions { get; set; } = default!;
}

public enum CategoryType
{
    Income,
    Expense
}