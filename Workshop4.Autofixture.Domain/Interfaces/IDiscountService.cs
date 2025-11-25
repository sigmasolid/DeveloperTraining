namespace Workshop4.AutoFixture.Domain.Interfaces;

public interface IDiscountService
{
    decimal Calculate(decimal price, decimal discountPercent);
}

public interface IUnusedInterface
{
    void DoSomething();
}

public interface IAnotherUnusedInterface
{
    int GetValue();
}