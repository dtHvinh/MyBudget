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
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string? Icon { get; private set; }
    public CategoryType Type { get; private set; }

    public ICollection<Transaction> Transactions { get; set; } = default!;
}

public enum CategoryType
{
    Income,
    Expense
}