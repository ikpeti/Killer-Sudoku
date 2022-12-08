using Microsoft.AspNetCore.Mvc;
using Sudoku.Api.Generators;
using Sudoku.Api.Solvers;
using Sudoku.Api.Tests;
using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuController : ControllerBase
    {
        private readonly ISudokuGenerator _generator;
        private readonly ISudokuBoard _sudokuBoard;

        public SudokuController(ISudokuGenerator generator, ISudokuBoard sudokuBoard)
        {
            _generator = generator;
            _sudokuBoard = sudokuBoard;
        }

        [HttpGet("/sudoku")]
        public Task<SudokuViewModel> GetSudoku()
        {
            var sudokuBoard = _generator.Generate();
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

        [HttpGet("/killer")]
        public Task<List<int>> GetResult()
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

        [HttpGet("/otherkiller")]
        public Task<List<int>> GetOtherKillerResult()
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

        [HttpGet("/othersudoku")]
        public Task<List<int>> OtherSudokuSolver()
        {
            var sudoku = new SudokuSolver(9, SudokuExamples.Extreme);
            sudoku.Print();
            sudoku.Solve();
            sudoku.Print();
            return Task.FromResult(sudoku.GetSolution());
        }

        [HttpGet("/otherkillersudoku")]
        public Task<List<int>> OtherKillerSolver()
        {
            var killersudoku = new KillerSolver(9, KillerSudokuExamples.SecondExample.KillerFields,
                KillerSudokuExamples.SecondExample.KillerValues);
            killersudoku.Print();
            killersudoku.Solve();
            killersudoku.Print();
            return Task.FromResult(killersudoku.GetSolution());
        }

        [HttpGet("/killergenerate")]
        public Task<KillerSudokuViewModel> GetKillerSudoku()
        {
            KillerSudokuGenerator killerGenerator = new KillerSudokuGenerator(_sudokuBoard, _generator);
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
    }
}
