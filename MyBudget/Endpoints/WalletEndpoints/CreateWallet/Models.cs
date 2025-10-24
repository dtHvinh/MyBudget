namespace MyBudget.Endpoints.WalletEndpoints.CreateWallet;

public record CreateWalletRequest(
    string Name,
    decimal InitialBalance,
    string Currency,
    string WalletType);

public record CreateWalletResponse(
    int WalletId,
    string Name,
    decimal Balance);
