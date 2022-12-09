using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Runners;
public interface IKillerSudokuRunner
{
    Task<KillerSudokuViewModel> GenerateKillerSudoku();
    Task<int[][]> GeneticSolve();
    Task<List<int>> RecursionSolve();
    Task<List<int>> RecursionKillerSolve();
    Task<List<int>> NumberListKillerSolve();
}