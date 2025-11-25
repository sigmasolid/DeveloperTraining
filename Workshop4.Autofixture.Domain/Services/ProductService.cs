using Workshop4.Autofixture.Domain.Interfaces;
using Workshop4.Autofixture.Domain.Models;

namespace Workshop4.Autofixture.Domain.Services;

public class ProductService
{
    private readonly IProductRepository _repo;
    private readonly DiscountService _discountService;

    public ProductService(IProductRepository repo, DiscountService discountService)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
    }

    public decimal GetFinalPrice(Guid productId)
    {
        var product = _repo.GetById(productId);
        if (product is null) throw new ArgumentException("Product not found", nameof(productId));

        return _discountService.Calculate(product.Price, product.DiscountPercent);
    }
}

