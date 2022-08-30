using BasicSolver;

var board = new SudokuBoard();

board.InitBoard(SudokuExamples.Kindergarten);

board.PrintBoard();

board.SolveBoard();

Console.WriteLine();

board.PrintBoard();
