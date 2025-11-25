using AutoFixture;
using Workshop4.Autofixture.Domain.ValueObjects;

namespace Workshop4.AutoFixture.Domain.Tests.Fixtures;

public class DomainCustomization: ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(() => new ProductId(Guid.NewGuid().ToString()));
    }
}