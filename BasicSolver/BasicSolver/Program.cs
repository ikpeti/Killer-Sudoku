using BasicSolver;

var board = new SudokuBoard();

board.Init(SudokuExamples.Kindergarten);

board.Print();

board.Solve();

Console.WriteLine();

board.Print();
