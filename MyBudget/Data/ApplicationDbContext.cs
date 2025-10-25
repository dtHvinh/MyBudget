using Microsoft.EntityFrameworkCore;
using MyBudget.Models;

namespace MyBudget.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; private set; } = default!;
    public DbSet<Transaction> Transactions { get; private set; } = default!;
    public DbSet<Wallet> Wallets { get; private set; } = default!;
    public DbSet<WalletType> WalletTypes { get; private set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .Property(c => c.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Transaction>()
            .Property(t => t.Type)
            .HasConversion<string>();

        modelBuilder.Entity<WalletType>()
            .HasData([
                new WalletType { Id = 1, Name = "Cash" },
                new WalletType { Id = 2, Name = "BankAccount" },
                new WalletType { Id = 3, Name = "CreditCard" },
                new WalletType { Id = 4, Name = "DigitalWallet" },
            ]);
    }
}
