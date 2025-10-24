using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.WalletEndpoints.DeleteWallet.ById;

public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<Results<NoContent, NotFound>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Delete("{id:int}");
        Group<WalletGroup>();
        Summary(s =>
        {
            s.Summary = "Deletes a wallet by its unique identifier.";
            s.Description = "Permanently removes a wallet from the system using its GUID.";
            s.Response(StatusCodes.Status204NoContent, "Wallet successfully deleted.");
            s.Response(StatusCodes.Status404NotFound, "Wallet not found.");
        });
    }

    public override async Task<Results<NoContent, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        Wallet? wallet = _context.Wallets.Find(Route<int>("id"));

        if (wallet is null)
            return TypedResults.NotFound();

        _context.Wallets.Remove(wallet);

        await _context.SaveChangesAsync(ct);

        return TypedResults.NoContent();
    }
}
