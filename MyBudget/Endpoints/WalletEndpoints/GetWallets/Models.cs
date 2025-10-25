using MyBudget.Utils.Request;

namespace MyBudget.Endpoints.WalletEndpoints.GetWallets;

public sealed class GetWalletRequest : PaginatioinParams
{

}

public sealed class GetWalletResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Balance { get; set; }
    public required string Currency { get; set; }
    public required string WalletType { get; set; }
    public required DateTimeOffset CreatedDate { get; set; }
}
