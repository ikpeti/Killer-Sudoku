using Sudoku.Api.Solvers;

namespace Sudoku.Api.Generators;
public interface ISudokuGenerator
{
    public ISudokuBoard Generate();
    public int[,] GenerateRookLayout();
}
