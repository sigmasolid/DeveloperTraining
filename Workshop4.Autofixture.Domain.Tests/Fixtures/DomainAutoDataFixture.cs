using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Workshop4.AutoFixture.Domain.Tests.Fixtures;

public class DomainAutoDataFixture : AutoDataAttribute
{
    public DomainAutoDataFixture(): base(() =>
    {
        var fixture = new Fixture();
        // Instruct the fixture to use NSubstitute for creating substitutes for interfaces and abstract classes
        fixture.Customize(new AutoNSubstituteCustomization());
        // Apply domain-specific customizations
        fixture.Customize(new DomainCustomization());
        return fixture;
    }) { }    
}