using FastEndpoints;

namespace MyBudget.Endpoints.WalletEndpoints;

public class WalletGroup : Group
{
    public WalletGroup()
    {
        Configure("wallets", g =>
        {
            g.AllowAnonymous();
        });
    }
}
