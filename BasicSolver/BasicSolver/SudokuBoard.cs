namespace BasicSolver;
public class SudokuBoard : ISudokuBoard
{
    public int Size { get; } = 9;
    public int[,] Board { get; }

    public SudokuBoard()
    {
        Board = new int[Size, Size];
    }

    public void Init(int[,] board)
    {
        if(board.Length != Math.Pow(Size, 2))
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
                        if(IsValidNumber(number, row, column))
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

    private bool IsNumberInRow(int number, int row)
    {
        for (var i = 0; i < Size; i++)
        {
            if (Board[row, i] == number)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsNumberInColumn(int number, int column)
    {
        for (var i = 0; i < Size; i++)
        {
            if (Board[i, column] == number)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsNumberInBox(int number, int row, int column)
    {
        var boxSize = (int)Math.Sqrt(Size);
        var boxRow = row - row % boxSize;
        var boxColumn = column - column % boxSize;

        for (var i = boxRow; i < boxRow + boxSize; i++)
        {
            for (var j = boxColumn; j < boxColumn + boxSize; j++)
            {
                if (Board[i, j] == number)
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
