using Moq;

namespace Workshop2.UnitTesting.Tests;

public class BarAppender_Should
{
    [Fact]
    public void AppendBar_When_AppendBarIsCalled()
    {
        // Arrange
        var someDependencyMock = new Mock<ISomeDependency>();
        var sut = new BarAppender(someDependencyMock.Object);
        var myString = "Some string";

        // Act
        var result = sut.AppendBar(myString);

        // Assert
        Assert.Equal($"{myString}Bar", result);
    }
    
    [Fact]
    public void CallDependencyWithCorrectInput_When_AppendBarIsCalled()
    {
        // Arrange
        var someDependencyMock = new Mock<ISomeDependency>();
        var sut = new BarAppender(someDependencyMock.Object);
        var myString = "Some string";

        // Act
        var result = sut.AppendBar(myString);

        // Assert
        someDependencyMock.Verify(x => 
            x.DoStuff($"Appending Bar to {myString}"));
    }
    
    [Fact]
    public void CallLoggerOnce_When_AppendBarIsCalled()
    {
        // Arrange
        var someDependencyMock = new Mock<ISomeDependency>();
        var sut = new BarAppender(someDependencyMock.Object);
        var myString = "Some string";

        // Act
        var result = sut.AppendBar(myString);

        // Assert
        someDependencyMock.Verify(x => 
            x.DoStuff($"Appending Bar to {myString}"), Times.Once);
    }
}