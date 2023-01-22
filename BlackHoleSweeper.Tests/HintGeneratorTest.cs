using BlackHolesSweeper;
using BlackHolesSweeper.Helpers;
using BlackHolesSweeper.Helpers.BlackHoleGenerator;
using Xunit;

namespace BlackHoleSweeper.Tests;

public class HintGeneratorTest
{
    [Fact]
    public void SetHintsShould_setHintsTo0_WhenThereIsNoBlackHole_InASize2Board()
    {
        var blackHolesGenerator = new RandomBlackHolesGenerator();
        var board = Board.CreateEmptyBoard(2);
        blackHolesGenerator.PlaceBlackHoles(0, board);
        HintGenerator.SetHints(board);

        foreach (var item in board.Squares) Assert.Equal(0, item.Hint);
    }

    [Fact]
    public void SetHintsShould_Set3HintsWithValue1_WhenThereIs1BlackHole_InASize2Board()
    {
        var board = Board.CreateEmptyBoard(2);
        var blackHolesGenerator = new RandomBlackHolesGenerator();
        blackHolesGenerator.PlaceBlackHoles(1, board);

        HintGenerator.SetHints(board);

        var squaresWithHintValueOne = board.Squares.Where(item => item.Hint == 1);
        Assert.Equal(3, squaresWithHintValueOne.Count());
    }

    [Fact]
    public void SetHintsShould_Set8HintsWithValue1_WhenThereIs1BlackHole_InTheMiddleOfASize3Board()
    {
        var board = Board.CreateEmptyBoard(3);
        var centerLocation = new Location(1, 1);
        var square = board.GetSquare(centerLocation);
        square.SetBlackHole();

        HintGenerator.SetHints(board);

        var squaresWithHintValueOne = board.Squares.Where(item => item.Hint == 1);
        Assert.Equal(8, squaresWithHintValueOne.Count());
    }

    [Fact]
    public void SetHintsShould_Set3HintsWithValue1_WhenThereIs1BlackHole_InTheTopLeftCornerOfASize3Board()
    {
        var board = Board.CreateEmptyBoard(3);
        var topLeft = new Location(0, 0);
        var square = board.GetSquare(topLeft);
        square.SetBlackHole();

        HintGenerator.SetHints(board);

        var squaresWithHintValueOne = board.Squares.Where(item => item.Hint == 1);
        var squaresWithHintValueZero = board.Squares.Where(item => item.Hint == 0);
        Assert.Equal(3, squaresWithHintValueOne.Count());
        Assert.Equal(6, squaresWithHintValueZero.Count());
    }

    [Fact]
    public void SetHintsShould_Set2HintsWithValue2_WhenThereAre2BlackHoles_InTheTopLineOfASize2Board()
    {
        var board = Board.CreateEmptyBoard(2);
        var topLeft = new Location(0, 0);
        var topLeftSquare = board.GetSquare(topLeft);
        topLeftSquare.SetBlackHole();
        var topRight = new Location(0, 1);
        var topRightSquare = board.GetSquare(topRight);
        topRightSquare.SetBlackHole();

        HintGenerator.SetHints(board);

        var squaresWithHintValueTwo = board.Squares.Where(item => item.Hint == 2);
        Assert.Equal(2, squaresWithHintValueTwo.Count());
    }
}
