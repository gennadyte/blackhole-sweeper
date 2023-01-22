using BlackHolesSweeper;
using BlackHoleSweeper.Tests.Helpers;
using Xunit;

namespace BlackHoleSweeper.Tests;

public class GameTest
{
    [Fact]
    public void SetUpShould_CreateA4by4HiddenBoard_WhenInputBoardSizeIs4()
    {
        const string boardSizeInput = "4";
        var input = new MockInput(new[] {boardSizeInput});
        var output = new MockOutput();
        var blackHolesGenerator = new MockBlackHolesGenerator();
        var game = new Game(input, output, blackHolesGenerator);
        game.CreateBoard();
        var result = game.Board.ToString();
        const string expectedResult = ". . . . \n" +
                                      ". . . . \n" +
                                      ". . . . \n" +
                                      ". . . . \n";

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GameShould_RevealEntireBoardAndWinTheGame_WhenInputLocationMatchesAllHintLocations()
    {
        const string boardSizeInput = "2";
        var input = new MockInput(new[] {boardSizeInput, "1,0", "1,1"});
        var output = new MockOutput();
        var blackHolesGenerator = new MockBlackHolesGenerator();
        var game = new Game(input, output, blackHolesGenerator);
        game.CreateBoard();
        game.Play();
        var result = game.Board.ToString();
        const string expectedResult = "* * \n" +
                                      "2 2 \n";
        Assert.Equal(expectedResult, result);
        Assert.Equal(GameState.Win, game.State);
    }

    [Fact]
    public void GameShould_RevealEntireBoardAndLoseTheGame_WhenInputLocationMatchesBlackHoleLocation()
    {
        const string boardSizeInput = "4";
        var input = new MockInput(new[] {boardSizeInput, "0,0"});
        var output = new MockOutput();
        var blackHolesGenerator = new MockBlackHolesGenerator();
        var game = new Game(input, output, blackHolesGenerator);
        game.CreateBoard();
        game.Play();
        var result = game.Board.ToString();
        const string expectedResult = "* * * * \n" +
                                      "2 3 3 2 \n" +
                                      "0 0 0 0 \n" +
                                      "0 0 0 0 \n";

        Assert.Equal(expectedResult, result);
        Assert.Equal(GameState.Lose, game.State);
    }
}