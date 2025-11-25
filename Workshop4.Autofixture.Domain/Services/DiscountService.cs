using Workshop4.AutoFixture.Domain.Interfaces;

namespace Workshop4.AutoFixture.Domain.Services;

public class DiscountService : IDiscountService
{
    /// <summary>
    /// Calculate final price after applying discount percent.
    /// </summary>
    /// <param name="price">non-negative base price</param>
    /// <param name="discountPercent">0..100</param>
    /// <returns>final price (>=0)</returns>
    public decimal Calculate(decimal price, decimal discountPercent)
    {
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "Price must be non-negative");
        if (discountPercent < 0 || discountPercent > 100) throw new ArgumentOutOfRangeException(nameof(discountPercent), "Discount must be between 0 and 100");

        var discount = price * (discountPercent / 100m);
        return price - discount;
    }
}
