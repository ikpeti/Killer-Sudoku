using Microsoft.AspNetCore.Mvc;
using Sudoku.Api.Runners;
using Sudoku.Models.ViewModels;

namespace Sudoku.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class KillerSudokuController : ControllerBase
{
    private readonly IKillerSudokuRunner runner;

    public KillerSudokuController(IKillerSudokuRunner runner)
    {
        this.runner = runner;
    }
    [HttpGet]
    public async Task<KillerSudokuViewModel> GetKillerSudoku()
    {
        return await runner.GenerateKillerSudoku();
    }

    [HttpGet("/killergenetic")]
    public async Task<int[][]> SolveKillerSudokuWithGenetic()
    {
        return await runner.GeneticSolve();
    }

    [HttpGet("/recursionsolver")]
    public async Task<List<int>> RecursionSolver()
    {
        return await runner.RecursionSolve();
    }

    [HttpGet("/recursionkillersolver")]
    public async Task<List<int>> RecursionKillerSolver()
    {
        return await runner.RecursionKillerSolve();
    }

    [HttpGet("/numberlistkiller")]
    public async Task<List<int>> NumberListKillerSolver()
    {
        return await runner.NumberListKillerSolve();
    }
}
