using Sudoku.Api.Genetic;
using Sudoku.Api.NumberList;
using Sudoku.Api.Recursive;
using Sudoku.Api.Tests;
using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Runners;
public class SudokuRunner : ISudokuRunner
{
    public Task<SudokuViewModel> GenerateSudoku()
    {
        var sudokuBoard = new SudokuGenerator().Generate();
        var solution = sudokuBoard;

        var boardList = new List<int>();
        for (int i = 0; i < sudokuBoard.Size; i++)
        {
            for (int j = 0; j < sudokuBoard.Size; j++)
            {
                boardList.Add(sudokuBoard.Board[i, j]);
            }
        }
        solution.Solve();
        solution.Print();
        var solutionList = new List<int>();
        for (int i = 0; i < solution.Size; i++)
        {
            for (int j = 0; j < solution.Size; j++)
            {
                solutionList.Add(solution.Board[i, j]);
            }
        }
        return Task.FromResult(new SudokuViewModel
        {
            Size = sudokuBoard.Size,
            Board = boardList,
            Solution = solutionList
        });
    }

    public Task<int[][]> GeneticSolve()
    {
        var solver = new GeneticAlgorithmRunner(GeneticTests.Easy);

        return Task.FromResult(solver.RunGeneticAlgorithm());
    }

    public Task<List<int>> SolveSudokuWithNumberListSolver()
    {
        var sudoku = new SudokuSolver(9, SudokuExamples.Extreme);
        sudoku.Print();
        sudoku.Solve();
        sudoku.Print();
        return Task.FromResult(sudoku.GetSolution());
    }
}