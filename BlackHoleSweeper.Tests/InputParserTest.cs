using BlackHolesSweeper.Helpers;
using Xunit;

namespace BlackHoleSweeper.Tests;

public class InputParserTest
{
    [Theory]
    [InlineData(1,1, "1,1")]
    [InlineData(2,1, "2,1")]
    [InlineData(5,5, "5,5")]
    [InlineData(20,20, "20,20")]
    public void CreateLocationBasedOnInputShould_ReturnLocationWithCorrectPropertyValue_BasedOnInput(int xValue, int yValue, string input)
    {
        var result = InputParser.CreateLocationBasedOnInput(input);
        Assert.Equal(xValue, result.X);
        Assert.Equal(yValue, result.Y);
    }
}