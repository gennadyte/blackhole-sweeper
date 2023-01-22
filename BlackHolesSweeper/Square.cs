namespace BlackHolesSweeper;

/// <summary>
/// represent a cell of board
/// </summary>
public class Square
{
    
    /// <summary>
    /// whether a cell contains black hole
    /// </summary>
    public bool IsBlackHole { get; private set; }

    /// <summary>
    /// whether a cell is open
    /// </summary>
    public bool IsRevealed { get; set; }

    /// <summary>
    /// count of adjacent black holes
    /// </summary>
    public int Hint { get; set; }
    
    /// <summary>
    /// Location of cell on the board
    /// </summary>
    public Location Location { get;}
    
    public Square(Location location)
    {
        IsRevealed = false;
        Location = location;
        IsBlackHole = false;
    }
    
    /// <summary>
    /// Marks cell as open
    /// </summary>
    public void Reveal()
    {
        IsRevealed = true;
    }

    /// <summary>
    /// Places a black hole into the cell
    /// </summary>
    public void SetBlackHole()
    {
        IsBlackHole = true;
    }
    
    /// <summary>
    /// Visual representation of cell
    /// </summary>
    /// <returns>
    /// '.' - closed cell
    /// '*' - black hole
    /// '3' - number of adjacent black holes
    /// </returns>
    public override string ToString()
    {
        if (!IsRevealed)
        {
            return ".";
        }
        
        return IsBlackHole ? "*" : Hint.ToString();
    }
}