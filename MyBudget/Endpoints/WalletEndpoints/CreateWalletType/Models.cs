namespace MyBudget.Endpoints.WalletEndpoints.CreateWalletType;

public sealed class CreateWalletTypeRequest
{
    public required string Name { get; set; }
}

public sealed class CreateWalletTypeResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}