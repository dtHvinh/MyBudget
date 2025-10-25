using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;

namespace MyBudget.Endpoints.WalletEndpoints.GetWallets;

public class Endpoint(ApplicationDbContext context) : Endpoint<GetWalletRequest, Ok<List<GetWalletResponse>>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Get("");
        Group<WalletGroup>();
        Summary(s => s.Summary = "Get all wallets with pagination");
    }

    public override async Task<Ok<List<GetWalletResponse>>> ExecuteAsync(
        GetWalletRequest req, CancellationToken ct)
    {
        List<GetWalletResponse> wallets = [.. _context.Wallets
            .Skip((req.Page - 1) * req.Limit)
            .Take(req.Limit)
            .Select(e => new GetWalletResponse(){
                Id = e.Id,
                Name = e.Name,
                Balance = e.Balance,
                Currency = e.Currency,
                WalletType = e.WalletType.ToString(),
                CreatedDate = e.CreatedDate
            })];

        return TypedResults.Ok(wallets);
    }
}
