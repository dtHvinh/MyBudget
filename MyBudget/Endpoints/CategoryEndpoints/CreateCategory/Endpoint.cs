using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Endpoints.CategoryEndpoints.CreateCategory;

public class Endpoint(ApplicationDbContext context) : Endpoint<CreateCategoryRequest, Results<Ok<CreateCategoryResponse>, ProblemHttpResult>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Post("");
        Summary(s => s.Summary = "Creates a new category");
        Group<CategoryGroup>();
    }

    public override async Task<Results<Ok<CreateCategoryResponse>, ProblemHttpResult>> ExecuteAsync(
        CreateCategoryRequest req, CancellationToken ct)
    {
        Category category = new()
        {
            Name = req.Name,
            Description = req.Description,
            Icon = req.Icon,
            Type = Enum.Parse<CategoryType>(req.Type, true)
        };

        _context.Categories.Add(category);

        try
        {
            await _context.SaveChangesAsync(ct);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(detail: ex.Message);
        }

        CreateCategoryResponse response = new()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            Icon = category.Icon,
            Type = category.Type.ToString()
        };

        return TypedResults.Ok(response);
    }
}
