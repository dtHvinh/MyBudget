using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;

namespace MyBudget.Endpoints.WalletEndpoints.GetWalletDetails.ById;

public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<Results<Ok<GetWalletDetailsResponse>, NotFound>>
{
    private readonly ApplicationDbContext context = context;

    public override void Configure()
    {
        Get("{id}");
        Group<WalletGroup>();
    }

    public override async Task<Results<Ok<GetWalletDetailsResponse>, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");

        GetWalletDetailsResponse? wallet = await context.Wallets
            .Where(e => e.Id == id)
            .Select(e => new GetWalletDetailsResponse()
            {
                Id = e.Id,
                Name = e.Name,
                Balance = e.Balance,
                Currency = e.Currency,
                Type = e.Type,
                CreatedDate = e.CreatedDate
            })
            .FirstOrDefaultAsync(ct);

        if (wallet is null)
            return TypedResults.NotFound();

        return TypedResults.Ok(wallet);
    }
}
