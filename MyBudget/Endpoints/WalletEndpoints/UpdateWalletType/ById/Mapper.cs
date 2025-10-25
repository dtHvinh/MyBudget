using MyBudget.Models;
using Riok.Mapperly.Abstractions;

namespace MyBudget.Endpoints.WalletEndpoints.UpdateWalletType.ById;

[Mapper]
public static partial class Mapper
{
    [MapperIgnoreSource(nameof(UpdateWalletTypeRequest.Id))]
    public static partial void ApplyTo(this UpdateWalletTypeRequest request, WalletType walletType);
}
