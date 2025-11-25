using NSubstitute;
using Workshop4.Autofixture.Domain.Interfaces;
using Workshop4.Autofixture.Domain.Models;
using Workshop4.Autofixture.Domain.Services;

namespace Workshop4.Autofixture.Domain.Tests;

public class ProductServiceShould
{
    [Fact]
    public void GetFinalPrice_ReturnsExpected_WhenProductExists()
    {
        // Arrange
        var product = new Product { Id = Guid.NewGuid(), Price = 100m, DiscountPercent = 10m };
        var repo = Substitute.For<IProductRepository>();
        repo.GetById(product.Id).Returns(product);
        var discount = new DiscountService();
        var sut = new ProductService(repo, discount);

        // Act
        var result = sut.GetFinalPrice(product.Id);

        // Assert
        Assert.Equal(90m, result);
    }

    [Fact]
    public void GetFinalPrice_ThrowsArgumentException_WhenProductNotFound()
    {
        // Arrange
        var repo = Substitute.For<IProductRepository>();
        var discount = new DiscountService();
        var sut = new ProductService(repo, discount);

        var id = Guid.NewGuid();
        repo.GetById(id).Returns((Product?)null);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => sut.GetFinalPrice(id));
    }

    [Fact]
    public void DiscountService_Throws_WhenNegativePrice()
    {
        var discount = new DiscountService();
        Assert.Throws<ArgumentOutOfRangeException>(() => discount.Calculate(-1m, 10m));
    }
}