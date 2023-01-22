using BlackHolesSweeper;
using BlackHolesSweeper.Helpers.BlackHoleGenerator;
using Xunit;

namespace BlackHoleSweeper.Tests;

public class RandomBlackHolesGeneratorTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9)]
    public void PlaceBlackHolesShould_CreateCorrectNumberBlackHoles(int number)
    {
        var board = Board.CreateEmptyBoard(3);
        var blackHolesGenerator = new RandomBlackHolesGenerator();
        blackHolesGenerator.PlaceBlackHoles(number, board);
        var blackHoles = board.Squares.Where(item => item.IsBlackHole);
        Assert.Equal(number, blackHoles.Count());
    }
}