using AutoFixture.Xunit2;
using NSubstitute;
using Workshop4.AutoFixture.Domain.Interfaces;
using Workshop4.AutoFixture.Domain.Models;
using Workshop4.AutoFixture.Domain.Services;
using Workshop4.AutoFixture.Domain.Tests.Fixtures;
using Workshop4.Autofixture.Domain.ValueObjects;

namespace Workshop4.AutoFixture.Domain.Tests;

public class ProductServiceShould
{
    [Fact]
    public void GetCorrectFinalPrice_When_ProductExists()
    {
        // Arrange
        var product = new Product { Id = new ProductId(Guid.NewGuid().ToString()), Price = 100m, DiscountPercent = 10m };
        var repo = Substitute.For<IProductRepository>();
        repo.GetById(product.Id).Returns(product);

        var discount = Substitute.For<IDiscountService>();
        // configure the discount service substitute to return 90 for these inputs
        discount.Calculate(product.Price, product.DiscountPercent).Returns(90m);
        
        var unused1 = Substitute.For<IUnusedInterface>();
        var unused2 = Substitute.For<IAnotherUnusedInterface>();

        var sut = new ProductService(repo, discount, unused1, unused2);

        // Act
        var result = sut.GetFinalPrice(product.Id);

        // Assert
        Assert.Equal(90m, result);
    }

    #region Autofixture Style

    [Theory]
    [DomainAutoDataFixture]
    public void GetCorrectFinalPrice_When_ProductExists_AutofixtureStyle(
        Product product,
        [Frozen] IDiscountService discountService,
        [Frozen] IProductRepository productRepository,
        decimal discountedPrice,
        ProductService sut)
    {
        // Arrange
        discountService.Calculate(product.Price, product.DiscountPercent).Returns(discountedPrice);
        productRepository.GetById(product.Id).Returns(product);
        
        // Act
        var result = sut.GetFinalPrice(product.Id);
        
        // Assert
        Assert.Equal(discountedPrice, result);
    }

    #endregion
    
    [Fact]
    public void ThrowArgumentException_WhenProductNotFound()
    {
        // Arrange
        var repo = Substitute.For<IProductRepository>();
        var discount = Substitute.For<IDiscountService>();
        var unused1 = Substitute.For<IUnusedInterface>();
        var unused2 = Substitute.For<IAnotherUnusedInterface>();
        var sut = new ProductService(repo, discount, unused1, unused2);

        var id = new ProductId(Guid.NewGuid().ToString());
        repo.GetById(id).Returns((Product?)null);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => sut.GetFinalPrice(id));
    }

    #region Autofixture Style

    [Theory]
    [DomainAutoDataFixture]
    public void ThrowArgumentException_WhenProductDoesNotExist(
        [Frozen] IProductRepository productRepository,
        ProductService sut)
    {
        // Arrange
        productRepository.GetById(Arg.Any<ProductId>()).Returns((Product?)null);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => sut.GetFinalPrice(Arg.Any<ProductId>()));
    }

    #endregion
}