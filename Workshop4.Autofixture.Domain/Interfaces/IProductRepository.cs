using Workshop4.AutoFixture.Domain.Models;
using Workshop4.Autofixture.Domain.ValueObjects;

namespace Workshop4.AutoFixture.Domain.Interfaces;

public interface IProductRepository
{
    Product? GetById(ProductId id);
}

