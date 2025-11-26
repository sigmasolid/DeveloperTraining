namespace Workshop2.UnitTesting;

public class BarAppender
{
    private readonly ISomeDependency _someDependency;

    public BarAppender(ISomeDependency someDependency)
    {
        _someDependency = someDependency;
    }

    public string AppendBar(string stringToAppendTo)
    {
        _someDependency.DoStuff($"Appending Bar to {stringToAppendTo}");
        return $"{stringToAppendTo}Bar";
    }
}