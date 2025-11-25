using Workshop4.Autofixture.Domain.ValueObjects;

namespace Workshop4.AutoFixture.Domain.Models;

public class Product
{
    public required ProductId Id { get; init; }
    public required decimal Price { get; init; }
    public required decimal DiscountPercent { get; init; }
}

