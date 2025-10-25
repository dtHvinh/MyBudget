using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.CategoryEndpoints.UpdateCategory.ById;

public class Endpoint(ApplicationDbContext context) : Endpoint<UpdateCategoryRequest, Results<NoContent, NotFound, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Put("{id:int}");
        Group<CategoryGroup>();
    }

    public override async Task<Results<NoContent, NotFound, ProblemHttpResult>> ExecuteAsync(UpdateCategoryRequest req, CancellationToken ct)
    {
        Category? category = await _context.Categories.FindAsync([req.Id], ct);

        if (category is null)
            return TypedResults.NotFound();

        req.ApplyTo(category);

        _context.Categories.Update(category);

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
