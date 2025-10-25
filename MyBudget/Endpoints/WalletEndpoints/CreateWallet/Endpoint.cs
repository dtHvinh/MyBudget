using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.WalletEndpoints.CreateWallet;

public class Endpoint(ApplicationDbContext context) : Endpoint<CreateWalletRequest, Results<Ok<CreateWalletResponse>, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Post("");
        Group<WalletGroup>();
        Summary(s => s.Summary = "Creates a new wallet for the user.");
    }

    public override async Task<Results<Ok<CreateWalletResponse>, ProblemHttpResult>> ExecuteAsync(
        CreateWalletRequest req, CancellationToken ct)
    {
        Wallet wallet = new(
            req.Name,
            req.InitialBalance,
            req.Currency);

        WalletType? walletType = await _context.WalletTypes
            .FindAsync(keyValues: [req.WalletTypeId], cancellationToken: ct);

        if (walletType is null)
        {
            return TypedResults.Problem(
                detail: $"Wallet type with id {req.WalletTypeId} not found.",
                statusCode: StatusCodes.Status400BadRequest,
                title: "Invalid wallet type");
        }

        wallet.WalletType = walletType;
        _context.Add(wallet);

        try
        {
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Fail to create new wallet");
        }

        var response = new CreateWalletResponse(
            wallet.Id,
            wallet.Name,
            wallet.Balance);

        return TypedResults.Ok(response);
    }
}