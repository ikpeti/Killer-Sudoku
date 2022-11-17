using Sudoku.Api.Enums;
using Sudoku.Api.Solvers;

namespace Sudoku.Api.Generators;
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

    public ISudokuBoard Generate()
    {
        _sudokuBoard.Init(GenerateRookLayout());

        _sudokuBoard.Solve();

        _sudokuBoard.Generate(SudokuTypes.HARD);

        while (_sudokuBoard.CheckGeneratedPuzzle() == 1)
        {
            _sudokuBoard.Init(GenerateRookLayout());

            _sudokuBoard.Solve();
            _sudokuBoard.Generate(SudokuTypes.HARD);
        }

        return _sudokuBoard;
    }

    private int[,] GenerateRookLayout()
    {
        var layout = new int[_size, _size];

        for (var i = 0; i < _size; i++)
        {
            var validIndexes = new List<int>
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8
            };

            int index = _random.Next(0, validIndexes.Count);

            while (!IsValidPlace(layout, i, validIndexes[index]))
            {
                validIndexes.RemoveAt(index);
                index = _random.Next(0, validIndexes.Count);
            }

            layout[i, validIndexes[index]] = _random.Next(1, 10);

        }

        return layout;
    }

    private bool IsValidPlace(int[,] layout, int row, int column)
    {
        return !IsNumberInColumn(layout, column) &&
            !IsNumberInBox(layout, row, column);
    }

    private bool IsNumberInBox(int[,] layout, int row, int column)
    {
        var boxSize = (int)Math.Sqrt(_size);
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

    private bool IsNumberInColumn(int[,] layout, int column)
    {
        for (int i = 0; i < _size; i++)
        {
            if (layout[i, column] != 0)
                return true;
        }

        return false;
    }
}
