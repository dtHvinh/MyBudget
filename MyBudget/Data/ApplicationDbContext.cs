using Microsoft.EntityFrameworkCore;
using MyBudget.Models;

namespace MyBudget.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; } = default!;
    public DbSet<Transaction> Transactions { get; } = default!;
    public DbSet<Wallet> Wallets { get; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .Property(c => c.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Transaction>()
            .Property(t => t.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Wallet>()
            .Property(w => w.Type)
            .HasConversion<string>();
    }
}
