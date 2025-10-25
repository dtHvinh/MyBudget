using FastEndpoints;

namespace MyBudget.Endpoints.WalletEndpoints;

public class WalletTypeGroup : Group
{
    public WalletTypeGroup()
    {
        Configure("types", g =>
        {
            g.AllowAnonymous();
            g.Group<WalletGroup>();
        });
    }
}
