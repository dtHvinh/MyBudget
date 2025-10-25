using MyBudget.Models;

namespace MyBudget.Endpoints.CategoryEndpoints.GetCategories;

public sealed class GetCategoriesResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string? Icon { get; set; }
    public required CategoryType Type { get; set; }
}
