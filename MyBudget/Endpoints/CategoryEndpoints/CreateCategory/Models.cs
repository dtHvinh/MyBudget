using FastEndpoints;
using FluentValidation;
using MyBudget.Models;

namespace MyBudget.Endpoints.CategoryEndpoints.CreateCategory;

public sealed class CreateCategoryRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? Icon { get; set; }
    public string Type { get; set; } = default!;

    public sealed class CreateCategoryRequestValidator : Validator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Icon)
                .MaximumLength(200);

            RuleFor(x => x.Type)
                .NotEmpty()
                .Must(type => Enum.TryParse(typeof(CategoryType), type, true, out _))
                .WithMessage($"Type must be one of the following values: {string.Join(", ", Enum.GetNames<CategoryType>())}");
        }
    }
}

public sealed class CreateCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? Icon { get; set; }
    public string Type { get; set; } = default!;
}