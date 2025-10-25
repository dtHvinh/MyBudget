namespace MyBudget.Models;

public class Category
{
    public Category(string name, string description, CategoryType type, string? icon = null)
    {
        Name = name;
        Description = description;
        Icon = icon;
        Type = type;
    }

    public Category()
    {

    }

    public int Id { get; private set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? Icon { get; set; }
    public CategoryType Type { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = default!;
}

public enum CategoryType
{
    Income,
    Expense,
    Transfer
}