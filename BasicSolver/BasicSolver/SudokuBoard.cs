namespace BasicSolver;
public class SudokuBoard
{
    private const int GRID_SIZE = 9;
    private readonly int[,] _board = new int[GRID_SIZE, GRID_SIZE];

    public void InitBoard(int[,] board)
    {
        if(board.Length != Math.Pow(GRID_SIZE, 2))
        {
            throw new ArgumentException("Board size does not equals to what was expected", nameof(board));
        }

        for (var i = 0; i < GRID_SIZE; i++)
        {
            for (var j = 0; j < GRID_SIZE; j++)
            {
                if (board[i, j] is < 0 or > GRID_SIZE)
                {
                    throw new ArgumentException("Board has an invalid element", nameof(board));
                }
            }
        }

        for (var i = 0; i < GRID_SIZE; i++)
        {
            for (var j = 0; j < GRID_SIZE; j++)
            {
                _board[i, j] = board[i, j];
            }
        }
    }

    public void PrintBoard()
    {
        for (var i = 0; i < GRID_SIZE; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                Console.WriteLine("---------------------");
            }

            for (var j = 0; j < GRID_SIZE; j++)
            {
                if (j % 3 == 0 && j != 0)
                {
                    Console.Write("| ");
                }

                Console.Write(_board[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    public bool SolveBoard()
    {
        for (var row = 0; row < GRID_SIZE; row++)
        {
            for (var column = 0; column < GRID_SIZE; column++)
            {
                if (_board[row, column] == 0)
                {
                    for (var number = 1; number <= GRID_SIZE; number++)
                    {
                        if(IsValidNumber(number, row, column))
                        {
                            _board[row, column] = number;

                            if (SolveBoard())
                            {
                                return true;
                            }
                            else
                            {
                                _board[row, column] = 0;
                            }
                        }
                    }

                    return false;
                }
            }
        }

        return true;
    }

    private bool IsNumberInRow(int number, int row)
    {
        for (var i = 0; i < GRID_SIZE; i++)
        {
            if (_board[row, i] == number)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsNumberInColumn(int number, int column)
    {
        for (var i = 0; i < GRID_SIZE; i++)
        {
            if (_board[i, column] == number)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsNumberInBox(int number, int row, int column)
    {
        var boxSize = (int)Math.Sqrt(GRID_SIZE);
        var boxRow = row - row % boxSize;
        var boxColumn = column - column % boxSize;

        for (var i = boxRow; i < boxRow + boxSize; i++)
        {
            for (var j = boxColumn; j < boxColumn + boxSize; j++)
            {
                if (_board[i, j] == number)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool IsValidNumber(int number, int row, int column)
    {
        return !IsNumberInRow(number, row) &&
            !IsNumberInColumn(number, column) &&
            !IsNumberInBox(number, row, column);
    }
}
