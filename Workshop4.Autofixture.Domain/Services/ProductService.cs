using Workshop4.AutoFixture.Domain.Interfaces;
using Workshop4.Autofixture.Domain.ValueObjects;

namespace Workshop4.AutoFixture.Domain.Services;

public class ProductService(
    IProductRepository repo,
    IDiscountService discountService,
    IUnusedInterface unused1,
    IAnotherUnusedInterface unused2)
{
    private readonly IProductRepository _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    private readonly IDiscountService _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
    private readonly IUnusedInterface _unusedInterface = unused1 ?? throw new ArgumentNullException(nameof(unused1));
    private readonly IAnotherUnusedInterface _anotherUnusedInterface = unused2 ?? throw new ArgumentNullException(nameof(unused2));

    public decimal GetFinalPrice(ProductId productId)
    {
        var product = _repo.GetById(productId);
        if (product is null) throw new ArgumentException("Product not found", nameof(productId));
        
        _unusedInterface.DoSomething();
        _anotherUnusedInterface.GetValue();

        return _discountService.Calculate(product.Price, product.DiscountPercent);
    }
}
