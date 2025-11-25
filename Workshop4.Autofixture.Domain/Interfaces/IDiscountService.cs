namespace Workshop4.Autofixture.Domain.Interfaces;

public interface IDiscountService
{
    decimal Calculate(decimal price, decimal discountPercent);
}

