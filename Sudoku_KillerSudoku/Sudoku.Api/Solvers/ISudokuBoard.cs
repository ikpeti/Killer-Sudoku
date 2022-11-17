using Sudoku.Api.Enums;

namespace Sudoku.Api.Solvers;
public interface ISudokuBoard
{
    public int Size { get; }
    public int[,] Board { get; }
    public void Init(int[,] board);
    public void Print();
    public bool Solve();
    public int CheckGeneratedPuzzle();
    public void Generate(SudokuTypes sudokuType);
}
