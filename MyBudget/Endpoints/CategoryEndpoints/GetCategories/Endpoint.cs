using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;

namespace MyBudget.Endpoints.CategoryEndpoints.GetCategories;

public class Endpoint(ApplicationDbContext context) : EndpointWithoutRequest<Ok<List<GetCategoriesResponse>>>
{
    private readonly ApplicationDbContext _context = context;

    public override void Configure()
    {
        Get("");
        Summary(s => s.Summary = "Get all categories");
        Group<CategoryGroup>();
    }

    public override async Task<Ok<List<GetCategoriesResponse>>> ExecuteAsync(CancellationToken ct)
    {
        List<GetCategoriesResponse> categoriesResponses =
            await _context.Categories
            .Select(c => new GetCategoriesResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Icon = c.Icon,
                Type = c.Type.ToString(),
            })
            .ToListAsync(ct);

        return TypedResults.Ok(
            categoriesResponses
        );
    }
}
