using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.CategoryEndpoints.DeleteCategory;

public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<Results<NoContent, NotFound, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Delete("{id:int}");
        Group<CategoryGroup>();
    }

    public override async Task<Results<NoContent, NotFound, ProblemHttpResult>> ExecuteAsync(CancellationToken ct)
    {
        Category? category = await _context.Categories.FindAsync([Route<int>("id")], ct);

        if (category is null)
            return TypedResults.NotFound();

        _context.Categories.Remove(category);

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
