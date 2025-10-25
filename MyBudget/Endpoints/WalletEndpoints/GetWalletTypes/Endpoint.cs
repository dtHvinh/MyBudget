using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;

namespace MyBudget.Endpoints.WalletEndpoints.GetWalletTypes;

public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<Ok<List<GetWalletTypesResponse>>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Get("types");
        Description(b => b
            .WithTags("Wallets")
            .Produces<List<GetWalletTypesResponse>>(StatusCodes.Status200OK)
            .WithSummary("Get Wallet Types")
            .WithDescription("Retrieves a list of available wallet types."));
        Group<WalletGroup>();
    }

    public override async Task<Ok<List<GetWalletTypesResponse>>> ExecuteAsync(CancellationToken ct)
    {
        var walletTypes = await _context.WalletTypes.Select(wt => new GetWalletTypesResponse
        {
            Id = wt.Id,
            Name = wt.Name,
        }).ToListAsync(ct);

        return TypedResults.Ok(walletTypes);
    }
}
