using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Workshop4.AutoFixture.Domain.Tests.Fixtures;

public class DomainAutoDataFixture : AutoDataAttribute
{
    public DomainAutoDataFixture(): base(() =>
    {
        var fixture = new Fixture();
        fixture.Customize(new AutoNSubstituteCustomization());
        // Add any other customizations here
        return fixture;
    })
    {
        
    }    
}