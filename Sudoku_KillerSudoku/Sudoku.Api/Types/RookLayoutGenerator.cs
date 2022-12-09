namespace Sudoku.Api.Types;
public class RookLayoutGenerator
{
    private readonly int size;
    private Random random;
    public RookLayoutGenerator(int size)
    {
        random = new Random();
        this.size = size;
    }
    public int[,] GenerateRookLayout()
    {
        var layout = new int[size, size];

        var validIndexes = new List<int>
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8
            };
        for (var i = 0; i < size; i++)
        {
            int index = random.Next(0, validIndexes.Count);

            while (!IsValidPlace(layout, i, validIndexes[index]))
            {
                index = random.Next(0, validIndexes.Count);
            }

            layout[i, validIndexes[index]] = 1;
            validIndexes.RemoveAt(index);
        }

        return layout;
    }

    private bool IsValidPlace(int[,] layout, int row, int column)
    {
        return !IsNumberInBox(layout, row, column);
    }

    private bool IsNumberInBox(int[,] layout, int row, int column)
    {
        var boxSize = (int)Math.Sqrt(size);
        var boxRow = row - row % boxSize;
        var boxColumn = column - column % boxSize;

        for (var i = boxRow; i < boxRow + boxSize; i++)
        {
            for (var j = boxColumn; j < boxColumn + boxSize; j++)
            {
                if (layout[i, j] != 0)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
