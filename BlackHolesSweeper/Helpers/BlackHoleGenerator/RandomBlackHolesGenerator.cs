namespace BlackHolesSweeper.Helpers.BlackHoleGenerator;

public class RandomBlackHolesGenerator : IGenerateBlackHoles
{
        
    private readonly Random _random = new();
        
    public void PlaceBlackHoles(int numberOfBlackHoles, Board board)
    {
        var selectedSquares = RandomlySelectSquares(numberOfBlackHoles, board);
        PlaceBlackHoleOnEachOfTheSelectedSquares(selectedSquares);
    }

    private static void PlaceBlackHoleOnEachOfTheSelectedSquares(IEnumerable<Square> selectedSquares)
    {
        foreach (var square in selectedSquares)
        {
            square.SetBlackHole();
        }
    }

    private IEnumerable<Square> RandomlySelectSquares(int number, Board board)
    {
        return board.Squares.OrderBy(x => _random.Next()).Take(number);
    }
}
