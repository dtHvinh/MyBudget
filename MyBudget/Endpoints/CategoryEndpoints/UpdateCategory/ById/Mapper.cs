using MyBudget.Models;
using Riok.Mapperly.Abstractions;

namespace MyBudget.Endpoints.CategoryEndpoints.UpdateCategory.ById;

[Mapper]
public static partial class Mapper
{
    [MapperIgnoreTarget(nameof(Category.Transactions))]
    public static partial void ApplyTo(this UpdateCategoryRequest source, Category target);
}
