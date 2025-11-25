using Workshop4.Autofixture.Domain.ValueObjects;

namespace Workshop4.AutoFixture.Domain.Models;

public class Product
{
    public ProductId Id { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPercent { get; set; }
}

