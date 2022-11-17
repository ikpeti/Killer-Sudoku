namespace Sudoku.Api.Types;
public class Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }

    public bool Equals(int x, int y)
    {
        return X == x && Y == y;
    }
}
