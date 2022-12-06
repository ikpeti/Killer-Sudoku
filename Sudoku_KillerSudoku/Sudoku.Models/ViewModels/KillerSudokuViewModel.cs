namespace Sudoku.Models.ViewModels
{
    public class KillerSudokuViewModel
    {
        public int Size { get; set; }
        public List<int> Board { get; set; } = default!;
        public List<int> Solution { get; set; } = default!;
        public List<List<int>> KillerFields { get; set; } = default!;
        public List<int> KillerValues { get; set; } = default!;
    }
}
