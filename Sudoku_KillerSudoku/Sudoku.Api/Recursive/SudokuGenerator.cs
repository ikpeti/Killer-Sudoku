using Sudoku.Api.NumberList;
using Sudoku.Api.Types;

namespace Sudoku.Api.Recursive;
public class SudokuGenerator
{
    private readonly SudokuBoard _sudokuBoard;
    private readonly int _size;

    public SudokuGenerator()
    {
        _sudokuBoard = new SudokuBoard();
        _size = _sudokuBoard.Size;
    }

    public SudokuBoard Generate()
    {
        SudokuSolver solver;
        do
        {
            _sudokuBoard.Init(new RookLayoutGenerator(_size).GenerateRookLayout());

            _sudokuBoard.Solve();

            _sudokuBoard.Generate();

            solver = new SudokuSolver(_size, _sudokuBoard.Board);
        } while (!solver.Solve());

        return _sudokuBoard;
    }
}
