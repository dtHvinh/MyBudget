using FastEndpoints;

namespace MyBudget.Endpoints.TransactionEndpoints;

public class TransactionGroup : Group
{
    public TransactionGroup()
    {
        Configure("transactions", cf =>
        {
            cf.AllowAnonymous();
        });
    }
}
