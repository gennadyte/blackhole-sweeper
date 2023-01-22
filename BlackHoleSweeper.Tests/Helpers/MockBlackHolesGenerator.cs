using BlackHolesSweeper;
using BlackHolesSweeper.Helpers.BlackHoleGenerator;

namespace BlackHoleSweeper.Tests.Helpers;

public class MockBlackHolesGenerator : IGenerateBlackHoles
{
    public void PlaceBlackHoles(int numberOfBlackHoles, Board board)
    {
        var selectedSquares = board.Squares.Take(numberOfBlackHoles);
        foreach (var item in selectedSquares)
        {
            item.SetBlackHole();
        }
    }
}