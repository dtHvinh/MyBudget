using FastEndpoints;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;

var bd = WebApplication.CreateBuilder(args);
var s = bd.Services;

s.AddOpenApi();
s.AddFastEndpoints();
s.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(new SqliteConnectionStringBuilder()
    {
        Mode = SqliteOpenMode.ReadWriteCreate,
        DataSource = "MyBudget.db",
    }.ToString());
});

var app = bd.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseFastEndpoints(cf =>
{
    cf.Endpoints.RoutePrefix = "api/v1";
});

app.Run();

