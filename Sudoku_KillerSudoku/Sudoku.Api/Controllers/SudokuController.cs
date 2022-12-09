using Microsoft.AspNetCore.Mvc;
using Sudoku.Api.NumberList;
using Sudoku.Api.Recursive;
using Sudoku.Api.Runners;
using Sudoku.Api.Tests;
using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SudokuController : ControllerBase
{
    private readonly ISudokuRunner runner;

    public SudokuController(ISudokuRunner runner)
    {
        this.runner = runner;
    }

    [HttpGet]
    public async Task<SudokuViewModel> GetSudoku()
    {
        return await runner.GenerateSudoku();
    }

    [HttpGet("/genetic")]
    public async Task<int[][]> SolveSudokuWithGenetic()
    {
        return await runner.GeneticSolve();
    }

    [HttpGet("/numberlistsudoku")]
    public async Task<List<int>> NumberListSudokuSolver()
    {
        return await runner.SolveSudokuWithNumberListSolver();
    }
}
