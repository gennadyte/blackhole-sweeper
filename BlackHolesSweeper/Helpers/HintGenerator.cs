namespace BlackHolesSweeper.Helpers;

public static class HintGenerator
{
    public static void SetHints(Board board)
    {
        if (BoardSizeIsTooSmall(board))
        {
            return;
        }

        if (BoardDoesNotContainAnyBlackHole(board))
        {
            return;
        }
        
        var blackHoles = GetBlackHoles(board);
        foreach (var item in blackHoles)
        {
            IncrementAllNeighboursHintValueByOne(board, item);
        }
    }

    private static IEnumerable<Square> GetBlackHoles(Board board) => 
        board.Squares.Where(item => item.IsBlackHole);

    private static void IncrementAllNeighboursHintValueByOne(Board board, Square item)
    {
        var neighbours = board.GetNeighbours(item);
        foreach (var neighbour in neighbours)
        {
            neighbour.Hint += 1;
        }
    }

    private static bool BoardSizeIsTooSmall(Board board) => 
        board.Length < 2;
    
    private static bool BoardDoesNotContainAnyBlackHole(Board board) => 
        !board.Squares.Any(square => square.IsBlackHole);
}
