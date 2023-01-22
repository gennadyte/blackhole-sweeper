namespace BlackHolesSweeper.Helpers;

public static class WinLoseChecker
{
    public static bool IsWinningConditionWhenAllHintsAreRevealed(Board currentBoard)
    {
        var hints = currentBoard.Squares.Where(item => !item.IsBlackHole);
        return hints.All(item => item.IsRevealed);
    }
        
    public static bool IsLosingConditionWhenOneBlackHoleIsRevealed(Board currentBoard)
    {
        var blackHoles = currentBoard.Squares.Where(item => item.IsBlackHole);
        return blackHoles.Any(item => item.IsRevealed);
    }
}