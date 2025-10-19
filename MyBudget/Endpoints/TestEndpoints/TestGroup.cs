using FastEndpoints;

namespace MyBudget.Endpoints.TestEndpoints;

public class TestGroup : Group
{
    public TestGroup()
    {
        Configure("test", c =>
        {
            c.Tags("Test Endpoints");
            c.AllowAnonymous();
        });
    }
}
