namespace BlackHolesSweeper;

public class Location
{
    public Location(int x, int y)
    {
        X = x;
        Y = y;
    }

    public  int X {get; }
    public  int Y {get; }

    public bool Equals(Location newLocation)
    {
        return (X == newLocation.X && Y == newLocation.Y);
    }
}
