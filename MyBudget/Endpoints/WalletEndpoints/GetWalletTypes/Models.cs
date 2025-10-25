namespace MyBudget.Endpoints.WalletEndpoints.GetWalletTypes;

public sealed class GetWalletTypesResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
