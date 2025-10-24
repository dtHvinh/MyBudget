﻿namespace MyBudget.Endpoints.WalletEndpoints.UpdateWallet.ById;

public sealed class UpdateWalletRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Balance { get; set; }
    public string? Currency { get; set; }
    public string? Type { get; set; }
}