using Microsoft.EntityFrameworkCore;
using MyBudget.Models;

namespace MyBudget.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; private set; } = default!;
    public DbSet<Transaction> Transactions { get; private set; } = default!;
    public DbSet<Wallet> Wallets { get; private set; } = default!;

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
