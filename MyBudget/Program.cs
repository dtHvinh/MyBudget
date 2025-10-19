using MyBudget.Data;

var bd = WebApplication.CreateBuilder(args);
var s = bd.Services;

s.AddOpenApi();
s.AddFastEndpoints();
s.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(bd.Configuration.GetConnectionString("Postgre"));
});

var app = bd.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();

