using Xunit;
using NSubstitute;
using Workshop4.Autofixture.Domain.Interfaces;
using Workshop4.Autofixture.Domain.Models;
using Workshop4.Autofixture.Domain.Services;

namespace Workshop4.Autofixture.Domain.Tests;

public class ProductServiceShould
{
    [Fact]
    public void GetCorrectFinalPrice_When_ProductExists()
    {
        // Arrange
        var product = new Product { Id = Guid.NewGuid(), Price = 100m, DiscountPercent = 10m };
        var repo = Substitute.For<IProductRepository>();
        repo.GetById(product.Id).Returns(product);

        var discount = Substitute.For<IDiscountService>();
        // configure the discount service substitute to return 90 for these inputs
        discount.Calculate(product.Price, product.DiscountPercent).Returns(90m);

        var sut = new ProductService(repo, discount);

        // Act
        var result = sut.GetFinalPrice(product.Id);

        // Assert
        Assert.Equal(90m, result);
    }

    [Fact]
    public void ThrowArgumentException_WhenProductNotFound()
    {
        // Arrange
        var repo = Substitute.For<IProductRepository>();
        var discount = Substitute.For<IDiscountService>();
        var sut = new ProductService(repo, discount);

        var id = Guid.NewGuid();
        repo.GetById(id).Returns((Product?)null);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => sut.GetFinalPrice(id));
    }
}