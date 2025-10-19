using FastEndpoints;

namespace MyBudget.Endpoints.TestEndpoints.GetTest;

public class GetString : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Get("string");
        Group<TestGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync("This is a test string response.", ct);
    }
}
