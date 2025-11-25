using Workshop4.AutoFixture.Domain.Models;

namespace Workshop4.AutoFixture.Domain.Interfaces;

public interface IProductRepository
{
    Product? GetById(Guid id);
}

