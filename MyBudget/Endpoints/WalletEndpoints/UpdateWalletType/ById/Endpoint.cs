using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.WalletEndpoints.UpdateWalletType.ById;

public class Endpoint(ApplicationDbContext context) : Endpoint<UpdateWalletTypeRequest, Results<NoContent, NotFound, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Put("{id:int}");
        Group<WalletTypeGroup>();
    }

    public override async Task<Results<NoContent, NotFound, ProblemHttpResult>> ExecuteAsync(UpdateWalletTypeRequest req, CancellationToken ct)
    {
        WalletType? walletType = await _context.WalletTypes.FindAsync([req.Id], ct);

        if (walletType is null)
        {
            return TypedResults.NotFound();
        }

        req.ApplyTo(walletType);

        _context.WalletTypes.Update(walletType);

        try
        {
            await _context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(detail: ex.Message);
        }

        return TypedResults.NoContent();
    }
}
