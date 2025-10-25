namespace MyBudget.Endpoints.WalletEndpoints.UpdateWalletType.ById;

public sealed class UpdateWalletTypeRequest
{
    public int Id { get; set; }
    public string? Name { get; set; } = default!;
}
