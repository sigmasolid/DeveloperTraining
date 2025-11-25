namespace Workshop4.Autofixture.Domain.ValueObjects;

public class ProductId
{
    public Guid Value { get; }
    
    public ProductId(string value)
    {
        Value = Guid.Parse(value);
    }
}