using MyBudget.Models;

namespace MyBudget.Endpoints.WalletEndpoints.GetWalletDetails.ById;

public sealed class GetWalletDetailsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Balance { get; set; }
    public string Currency { get; set; } = default!;
    public WalletType Type { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}