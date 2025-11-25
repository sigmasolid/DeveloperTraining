using Workshop4.Autofixture.Domain.Interfaces;
using Workshop4.Autofixture.Domain.Models;

namespace Workshop4.Autofixture.Domain.Services;

public class ProductService
{
    private readonly IProductRepository _repo;
    private readonly IDiscountService _discountService;
    private readonly IUnusedInterface _unusedInterface;
    private readonly IAnotherUnusedInterface _anotherUnusedInterface;

    public ProductService(IProductRepository repo, IDiscountService discountService, IUnusedInterface unused1, IAnotherUnusedInterface unused2)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
        _unusedInterface = unused1 ?? throw new ArgumentNullException(nameof(unused1));
        _anotherUnusedInterface = unused2 ?? throw new ArgumentNullException(nameof(unused2));
    }

    public decimal GetFinalPrice(Guid productId)
    {
        var product = _repo.GetById(productId);
        if (product is null) throw new ArgumentException("Product not found", nameof(productId));
        
        _unusedInterface.DoSomething();
        _anotherUnusedInterface.GetValue();

        return _discountService.Calculate(product.Price, product.DiscountPercent);
    }
}
