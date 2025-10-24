using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.WalletEndpoints.UpdateWallet.ById;

public class Endpoint(ApplicationDbContext context) : Endpoint<UpdateWalletRequest, Results<Ok, NotFound, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Put("{id:int}");
        Group<WalletGroup>();
        Summary(s => s.Summary = "Updates an existing wallet.");
    }

    public override async Task<Results<Ok, NotFound, ProblemHttpResult>> ExecuteAsync(
        UpdateWalletRequest req, CancellationToken ct)
    {
        Wallet? wallet = await _context.Wallets.FirstOrDefaultAsync(e => e.Id == req.Id, ct);

        if (wallet is null)
            return TypedResults.NotFound();

        req.ApplyTo(wallet);

        _context.Wallets.Update(wallet);

        try
        {
            await _context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(detail: ex.Message);
        }

        return TypedResults.Ok();
    }
}
