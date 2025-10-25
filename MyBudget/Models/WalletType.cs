using Microsoft.EntityFrameworkCore;

namespace MyBudget.Models;

[Index(nameof(Name), IsUnique = true)]
public sealed class WalletType
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
