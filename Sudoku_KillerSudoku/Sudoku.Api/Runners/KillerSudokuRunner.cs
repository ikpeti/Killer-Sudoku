using Sudoku.Api.Genetic;
using Sudoku.Api.NumberList;
using Sudoku.Api.Recursive;
using Sudoku.Api.Tests;
using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Runners;
public class KillerSudokuRunner : IKillerSudokuRunner
{
    public Task<KillerSudokuViewModel> GenerateKillerSudoku()
    {
        KillerSudokuGenerator killerGenerator = new KillerSudokuGenerator();
        var solution = killerGenerator.Generate();

        var board = new List<int>();

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                board.Add(killerGenerator.KillerBoard[i, j]);
            }
        }

        return Task.FromResult(new KillerSudokuViewModel
        {
            Size = killerGenerator.Size,
            Board = board,
            Solution = solution,
            KillerFields = killerGenerator.KillerFields,
            KillerValues = killerGenerator.KillerValues
        });
    }

    public Task<int[][]> GeneticSolve()
    {
        var solver = new GeneticAlgorithmRunner(GeneticTests.EasyKiller);

        return Task.FromResult(solver.RunGeneticAlgorithm());
    }

    public Task<List<int>> NumberListKillerSolve()
    {
        var killersudoku = new KillerSolver(9, KillerSudokuExamples.SecondExample.KillerFields,
            KillerSudokuExamples.SecondExample.KillerValues);
        killersudoku.Print();
        killersudoku.Solve();
        killersudoku.Print();
        return Task.FromResult(killersudoku.GetSolution());
    }

    public Task<List<int>> RecursionKillerSolve()
    {
        var killerSudoku = new KillerSudokuBoard(KillerSudokuExamples.RecursionSecondExample);
        killerSudoku.KillerSolve();
        var solutionList = new List<int>();
        for (int i = 0; i < killerSudoku.Size; i++)
        {
            for (int j = 0; j < killerSudoku.Size; j++)
            {
                solutionList.Add(killerSudoku.Board[i, j]);
            }
        }
        return Task.FromResult(new List<int>(solutionList));
    }

    public Task<List<int>> RecursionSolve()
    {
        var killerSudoku = new KillerSudokuBoard(KillerSudokuExamples.RecursionThirdExample);
        killerSudoku.Solve();
        var solutionList = new List<int>();
        for (int i = 0; i < killerSudoku.Size; i++)
        {
            for (int j = 0; j < killerSudoku.Size; j++)
            {
                solutionList.Add(killerSudoku.Board[i, j]);
            }
        }
        return Task.FromResult(new List<int>(solutionList));
    }
}
