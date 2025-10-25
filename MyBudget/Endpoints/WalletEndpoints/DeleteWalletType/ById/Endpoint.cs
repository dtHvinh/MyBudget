using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.WalletEndpoints.DeleteWalletType.ById;

public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<Results<Ok, NotFound>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Delete("{id}");
        Description(b => b
            .WithTags("Wallets")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Delete Wallet Type by ID")
            .WithDescription("Deletes a wallet type specified by its ID."));
        Group<WalletTypeGroup>();
    }
    public override async Task<Results<Ok, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        WalletType? walletType = await _context.WalletTypes.FindAsync([Route<int>("id")], ct);

        if (walletType is null)
        {
            return TypedResults.NotFound();
        }

        _context.WalletTypes.Remove(walletType);

        await _context.SaveChangesAsync(ct);

        return TypedResults.Ok();
    }
}
