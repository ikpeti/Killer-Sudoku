namespace Sudoku.Api.Types;
public class KillerComparer : IComparer<List<Coordinate>>
{
    public int Compare(List<Coordinate>? x, List<Coordinate>? y)
    {
        if (x == null || y == null)
            return 0;
        return x.Count < y.Count ? -1 : 1;
    }
}
