namespace MyBudget.Endpoints.CategoryEndpoints.UpdateCategory.ById;

public sealed class UpdateCategoryRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public string? Type { get; set; }
}
