namespace Sudoku.Api.Recursive;
public class SudokuBoard
{
    public int Size { get; } = 9;
    public virtual int[,] Board { get; protected set; }

    private Random _random;

    public SudokuBoard()
    {
        Board = new int[Size, Size];
        _random = new Random();
    }

    public void Init(int[,] board)
    {
        if (board.Length != Math.Pow(Size, 2))
        {
            throw new ArgumentException("Board size does not equals to what was expected", nameof(board));
        }

        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                if (board[i, j] < 0 || board[i, j] > Size)
                {
                    throw new ArgumentException("Board has an invalid element", nameof(board));
                }
            }
        }

        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                Board[i, j] = board[i, j];
            }
        }
    }

    public void Print()
    {
        for (var i = 0; i < Size; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                Console.WriteLine("---------------------");
            }

            for (var j = 0; j < Size; j++)
            {
                if (j % 3 == 0 && j != 0)
                {
                    Console.Write("| ");
                }

                Console.Write(Board[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    public bool Solve()
    {
        for (var row = 0; row < Size; row++)
        {
            for (var column = 0; column < Size; column++)
            {
                if (Board[row, column] == 0)
                {
                    for (var number = 1; number <= Size; number++)
                    {
                        if (IsValidNumber(number, row, column, Board))
                        {
                            Board[row, column] = number;

                            if (Solve())
                            {
                                return true;
                            }
                            else
                            {
                                Board[row, column] = 0;
                            }
                        }
                    }

                    return false;
                }
            }
        }

        return true;
    }

    public int CheckGeneratedPuzzle()
    {
        List<int[,]> result = new List<int[,]>();
        int[,] board = new int[Size, Size];
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                board[i, j] = Board[i, j];
            }
        }

        TryToSolve(result, board);
        return result.Count;
    }

    private bool TryToSolve(List<int[,]> result, int[,] board)
    {
        for (var row = 0; row < Size; row++)
        {
            for (var column = 0; column < Size; column++)
            {
                if (board[row, column] == 0)
                {
                    for (var number = 1; number <= Size; number++)
                    {
                        if (IsValidNumber(number, row, column, board))
                        {
                            board[row, column] = number;

                            TryToSolve(result, board);

                            board[row, column] = 0;
                        }
                    }

                    return false;
                }
            }
        }

        result.Add(board);
        return true;
    }

    private bool IsNumberInRow(int number, int row, int[,] board)
    {
        for (var i = 0; i < Size; i++)
        {
            if (board[row, i] == number)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsNumberInColumn(int number, int column, int[,] board)
    {
        for (var i = 0; i < Size; i++)
        {
            if (board[i, column] == number)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsNumberInBox(int number, int row, int column, int[,] board)
    {
        var boxSize = (int)Math.Sqrt(Size);
        var boxRow = row - row % boxSize;
        var boxColumn = column - column % boxSize;

        for (var i = boxRow; i < boxRow + boxSize; i++)
        {
            for (var j = boxColumn; j < boxColumn + boxSize; j++)
            {
                if (board[i, j] == number)
                {
                    return true;
                }
            }
        }

        return false;
    }

    protected virtual bool IsValidNumber(int number, int row, int column, int[,] board)
    {
        return !IsNumberInRow(number, row, board) &&
            !IsNumberInColumn(number, column, board) &&
            !IsNumberInBox(number, row, column, board);
    }

    public void Generate()
    {
        int numOfCells = 32;

        List<int> remainingCells = new List<int>();

        for (int i = 0; i < numOfCells; i++)
        {
            var newCell = _random.Next(1, Size * Size);
            while (remainingCells.Contains(newCell))
            {
                newCell = _random.Next(1, Size * Size);
            }
            remainingCells.Add(newCell);
        }

        int k = 1;
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (!remainingCells.Contains(k))
                    Board[i, j] = 0;
                k++;
            }
        }
    }
}
