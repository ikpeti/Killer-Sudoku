using System;

namespace Killer_Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Size:");
            SudokuBoard sb = new SudokuBoard(Convert.ToInt32(Console.ReadLine()));
            sb.ReadInput();
            sb.ShowBoard();
        }
    }
}
