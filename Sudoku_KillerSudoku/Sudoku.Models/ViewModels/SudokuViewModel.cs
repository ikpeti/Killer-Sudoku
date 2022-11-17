using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models.ViewModels;
public class SudokuViewModel
{
    public int Size { get; set; }
    public List<int> Board { get; set; } = default!;
    public List<int> Solution { get; set; } = default!;
}
