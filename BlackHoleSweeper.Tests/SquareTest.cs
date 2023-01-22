using BlackHolesSweeper;
using Xunit;

namespace BlackHoleSweeper.Tests;

public class SquareTest
{
    [Fact]
    public void ToStringShould_ReturnADotString_WhenSquareIsNotBlackHoleAndIsNotRevealed()
    {
        var location = new Location(1, 1);
        var square = new Square(location);
        var result = square.ToString();
        Assert.Equal(".", result);
    }

    [Fact]
    public void ToStringShould_ReturnADotString_WhenSquareIsBlackHoleAndIsNotRevealed()
    {
        var location = new Location(1, 1);
        var square = new Square(location);
        square.SetBlackHole();
        var result = square.ToString();
        Assert.Equal(".", result);
    }

    [Fact]
    public void ToStringShould_ReturnAStarString_WhenSquareIsBlackHoleAndIsRevealed()
    {
        var location = new Location(1, 1);
        var square = new Square(location);
        square.SetBlackHole();
        square.Reveal();
        var result = square.ToString();
        Assert.Equal("*", result);
    }

    [Fact]
    public void ToStringShould_ReturnValueString_WhenSquareIsNotBlackHoleAndIsRevealed()
    {
        var location = new Location(1, 1);
        var square = new Square(location);
        square.Reveal();
        var result = square.ToString();
        Assert.Equal("0", result);
    }
}
