using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.WalletEndpoints.CreateWalletType;

public class Endpoint(ApplicationDbContext context) : Endpoint<CreateWalletTypeRequest, Results<Ok<CreateWalletTypeResponse>, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Post("");
        Group<WalletTypeGroup>();
    }

    public override async Task<Results<Ok<CreateWalletTypeResponse>, ProblemHttpResult>> ExecuteAsync(
        CreateWalletTypeRequest req, CancellationToken ct)
    {
        WalletType walletType = new()
        {
            Name = req.Name
        };

        _context.WalletTypes.Add(walletType);

        try
        {
            await _context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(detail: ex.Message, statusCode: 500);
        }

        CreateWalletTypeResponse response = new()
        {
            Id = walletType.Id,
            Name = walletType.Name
        };

        return TypedResults.Ok(response);
    }
}
