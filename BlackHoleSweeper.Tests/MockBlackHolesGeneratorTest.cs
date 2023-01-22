using BlackHolesSweeper;
using BlackHoleSweeper.Tests.Helpers;
using Xunit;

namespace BlackHoleSweeper.Tests;

public class MockBlackHolesGeneratorTest
{
        
    [Fact]
    public void PlaceBlackHolesShould_SetSquaresOnTheTopRowToBlackHoles_WhenThereAre2BlackHolesOnASize2Board()
    {
        var board = Board.CreateEmptyBoard(2);
        var blackHolesGenerator = new MockBlackHolesGenerator();
        blackHolesGenerator.PlaceBlackHoles(2, board);
        board.RevealAllSquares();
            
        const string expectedResult = "* * \n" +
                                      "0 0 \n";
            
        Assert.Equal(expectedResult, board.ToString());
    }
        
    [Fact]
    public void PlaceBlackHolesShould_SetSquaresOnTopLeftCornerToBlackHoles_WhenThereAre1BlackHoleOnASize2Board()
    {
        var board = Board.CreateEmptyBoard(2);
        var blackHolesGenerator = new MockBlackHolesGenerator();
        blackHolesGenerator.PlaceBlackHoles(1, board);
        board.RevealAllSquares();
            
        const string expectedResult = "* 0 \n" +
                                      "0 0 \n";
            
        Assert.Equal(expectedResult, board.ToString());
    }
        
        
    [Fact]
    public void PlaceBlackHolesShould_SetSquaresOnTheTopRowToBlackHoles_WhenThereAre4BlackHolesOnASize4Board()
    {
        var board = Board.CreateEmptyBoard(4);
        var blackHolesGenerator = new MockBlackHolesGenerator();
        blackHolesGenerator.PlaceBlackHoles(4, board);
        board.RevealAllSquares();
            
        const string expectedResult = "* * * * \n" +
                                      "0 0 0 0 \n" +
                                      "0 0 0 0 \n" +
                                      "0 0 0 0 \n";
            
        Assert.Equal(expectedResult, board.ToString());
    }
}
