using FastEndpoints;
using FluentValidation;

namespace MyBudget.Endpoints.TransactionEndpoints.CreateTransaction;

public sealed class CreateTransactionRequest
{
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset Date { get; set; }
    public int WalletId { get; set; }
    public int CategoryId { get; set; }
    public string Type { get; set; } = default!;

    public sealed class CreateTransactionValidator : Validator<CreateTransactionRequest>
    {
        public CreateTransactionValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);

            RuleFor(x => x.Type).NotEmpty().Must(t => t is "Income" or "Expense" or "Transfer")
                .WithMessage("Type must be one of the following values: Income, Expense, Transfer");
        }
    }
}
