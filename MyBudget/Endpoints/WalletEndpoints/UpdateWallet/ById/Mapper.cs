using MyBudget.Endpoints.WalletEndpoints.UpdateWallet.ById;
using MyBudget.Models;
using Riok.Mapperly.Abstractions;

namespace MyBudget.Endpoints.WalletEndpoints.UpdateWallet;

[Mapper]
public static partial class Mapper
{
    [MapperIgnoreTarget(nameof(Wallet.Transactions))]
    public static partial void ApplyTo(this UpdateWalletRequest request, Wallet wallet);
}
