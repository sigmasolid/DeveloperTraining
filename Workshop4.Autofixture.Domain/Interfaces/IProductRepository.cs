using Workshop4.Autofixture.Domain.Models;

namespace Workshop4.Autofixture.Domain.Interfaces;

public interface IProductRepository
{
    Product? GetById(Guid id);
}

