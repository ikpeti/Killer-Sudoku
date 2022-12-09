using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Runners;
public interface ISudokuRunner
{
    Task<SudokuViewModel> GenerateSudoku();
    Task<int[][]> GeneticSolve();
    Task<List<int>> SolveSudokuWithNumberListSolver();
}
