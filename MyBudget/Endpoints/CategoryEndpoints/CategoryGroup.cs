using FastEndpoints;

namespace MyBudget.Endpoints.CategoryEndpoints;

public class CategoryGroup : Group
{
    public CategoryGroup()
    {
        Configure("categories", cf =>
        {
            cf.AllowAnonymous();
        });
    }
}
