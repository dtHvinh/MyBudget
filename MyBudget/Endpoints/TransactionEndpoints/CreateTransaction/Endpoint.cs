using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.TransactionEndpoints.CreateTransaction;

public class Endpoint(ApplicationDbContext context) : Endpoint<CreateTransactionRequest, Results<NoContent, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Post("");
        Group<TransactionGroup>();
    }
    public override async Task<Results<NoContent, ProblemHttpResult>> HandleAsync(
        CreateTransactionRequest req, CancellationToken ct)
    {
        Transaction transaction = new()
        {
            Amount = req.Amount,
            Note = req.Note,
            Date = req.Date,
            Type = Enum.Parse<TransactionType>(req.Type, true),
            WalletId = req.WalletId,
            CategoryId = req.CategoryId
        };

        _context.Transactions.Add(transaction);

        try
        {
            await _context.SaveChangesAsync(ct);
            return TypedResults.NoContent();
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
