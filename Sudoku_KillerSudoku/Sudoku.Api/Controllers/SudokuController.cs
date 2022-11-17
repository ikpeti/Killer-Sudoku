using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sudoku.Api.Generators;
using Sudoku.Api.Solvers;
using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuController : ControllerBase
    {
        private readonly ISudokuGenerator _generator;

        public SudokuController(ISudokuGenerator generator)
        {
            _generator = generator;
        }

        [HttpGet]
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
            var killerSudoku = new KillerSudokuBoard();
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
            var killerSudoku = new KillerSudokuBoard();
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
    }
}
