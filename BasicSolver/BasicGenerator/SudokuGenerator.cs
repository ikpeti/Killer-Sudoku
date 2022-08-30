
using BasicSolver;

namespace BasicGenerator;
public class SudokuGenerator : ISudokuGenerator
{
    private readonly ISudokuBoard _sudokuBoard;
    private readonly int _size;
    private readonly Random _random;

    public SudokuGenerator(ISudokuBoard sudokuBoard)
    {
        _sudokuBoard = sudokuBoard;
        _size = _sudokuBoard.Size;
        _random = new Random();
    }

    public void Generate()
    {
        _sudokuBoard.Init(GenerateRookLayout());

        _sudokuBoard.Solve();
    }

    private int[,] GenerateRookLayout()
    {
        var layout = new int[_size, _size];

        for (var i = 0; i < _size; i++)
        {
            var validIndexes = new List<int>()
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8
            };

            int index;

            do
            {
                index = _random.Next(0, validIndexes.Count - 1);
            } while (IsValidPlace(validIndexes[index]));
        }

        return layout;
    }

    private bool IsValidPlace(int index)
    {
        throw new NotImplementedException();
    }
}
