using BlackHolesSweeper.Helpers;
using Xunit;

namespace BlackHoleSweeper.Tests;

public class InputValidatorTest
{
    [Theory]
    [InlineData("10")]
    [InlineData("2")]
    public void IsValidBoardSizeShould_ReturnTrue_WhenInputIsAnIntegerLargerThan1(string input)
    {
        var result = InputValidator.IsValidBoardSizeInput(input);
        Assert.True(result);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-1")]
    [InlineData("-100")]
    public void IsValidBoardSizeShould_ReturnFalse_WhenInputIsAnIntegerLessOrEqualTo0(string input)
    {
        var result = InputValidator.IsValidBoardSizeInput(input);
        Assert.False(result);
    }
        
    [Theory]
    [InlineData("Lan")]
    [InlineData("0,0")]
    [InlineData("00,0")]
    [InlineData("1.2")]
    public void IsValidBoardSizeShould_ReturnFalse_WhenInputIsNotAnInteger(string input)
    {
        var result = InputValidator.IsValidBoardSizeInput(input);
        Assert.False(result);
    }

    [Theory]
    [InlineData("0,0")]
    [InlineData("3,3")]
    [InlineData("1,1")]
    public void IsValidLocationInputShould_ReturnTrue_WhenInputIsFormatIsCorrect(string input)
    {
        var result = InputValidator.IsValidLocationInput(input);
        Assert.True(result);
    }
        
    [Theory]
    [InlineData("0")]
    [InlineData("5.5")]
    [InlineData("7&28")]
    public void IsValidLocationInputShould_ReturnFalse_WhenInputFormatIsWrong(string input)
    {
        var result = InputValidator.IsValidLocationInput(input);
        Assert.False(result);
    }
}
