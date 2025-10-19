using FastEndpoints;

var bd = WebApplication.CreateBuilder(args);
var s = bd.Services;

s.AddOpenApi();
s.AddFastEndpoints();

var app = bd.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();

