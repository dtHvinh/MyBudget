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
        var wallet = new Wallet(
            req.Name,
            req.InitialBalance,
            req.Currency,
            Enum.Parse<WalletType>(req.WalletType, true));

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