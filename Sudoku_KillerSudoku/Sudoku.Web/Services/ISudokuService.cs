using Sudoku.Models.ViewModels;

namespace Sudoku.Web.Services;
public interface ISudokuService
{
    Task<SudokuViewModel?> GetSudoku();
}
