using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.TransactionEndpoints.DeleteTransaction;

public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<Results<NoContent, NotFound, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Delete("{id:int}");
        Group<TransactionGroup>();
    }

    public override async Task<Results<NoContent, NotFound, ProblemHttpResult>> ExecuteAsync(CancellationToken ct)
    {
        Transaction? transaction = await _context.Transactions.FindAsync([Route<int>("id")], ct);

        if (transaction is null)
        {
            return TypedResults.NotFound();
        }

        _context.Transactions.Remove(transaction);

        try
        {
            await _context.SaveChangesAsync(ct);
            return TypedResults.NoContent();
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(detail: ex.Message);
        }
    }
}
