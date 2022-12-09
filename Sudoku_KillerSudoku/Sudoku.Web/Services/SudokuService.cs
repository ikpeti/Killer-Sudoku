using Sudoku.Models.ViewModels;
using System.Net.Http.Json;

namespace Sudoku.Web.Services;
public class SudokuService : ISudokuService
{
    private readonly HttpClient _httpClient;

    public SudokuService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SudokuViewModel?> GetSudoku()
    {
        var sudokuViewModel = await _httpClient.GetFromJsonAsync<SudokuViewModel?>("/api/sudoku");

        return sudokuViewModel;
    }

    public async Task<KillerSudokuViewModel?> GetKillerSudoku()
    {
        var killersudokuViewModel = await _httpClient.GetFromJsonAsync<KillerSudokuViewModel?>("/api/killersudoku");

        return killersudokuViewModel;
    }
}