using Sudoku.Api.Types;

namespace Sudoku.Api.Solvers;
public class KillerSudokuBoard : SudokuBoard
{
    private Dictionary<List<Coordinate>, int> _killerValues;
    private SortedList<List<Coordinate>, int> _killerValuesSorted;
    public KillerSudokuBoard(Dictionary<List<Coordinate>, int> killerValues)
    {
        _killerValues = killerValues;
        _killerValuesSorted = new SortedList<List<Coordinate>, int>(new KillerComparer());

        foreach (var item in _killerValues)
        {
            _killerValuesSorted.Add(item.Key, item.Value);
        }
    }

    protected override bool IsValidNumber(int number, int row, int column, int[,] board)
    {
        if (!base.IsValidNumber(number, row, column, board))
            return false;

        foreach (var key in _killerValues.Keys)
        {
            bool inThisKey = false;
            foreach (var coordinate in key)
            {
                if (coordinate.Equals(row, column))
                {
                    inThisKey = true;
                }
            }

            if (inThisKey)
            {
                int sum = 0;
                int countOfEmpty = 0;
                List<int> availableNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                foreach (var coordinate in key)
                {
                    if (coordinate.Equals(row, column))
                    {
                        sum += number;
                        availableNumbers.Remove(number);
                    }
                    else
                    {
                        if (board[coordinate.X, coordinate.Y] == 0)
                            countOfEmpty++;
                        else
                        {
                            if (board[coordinate.X, coordinate.Y] == number)
                                return false;
                            sum += board[coordinate.X, coordinate.Y];
                            availableNumbers.Remove(board[coordinate.X, coordinate.Y]);
                        }
                    }
                }
                return AreKillerValuesValid(countOfEmpty, sum, availableNumbers, key);
            }
        }
        return false;
    }

    private bool AreKillerValuesValid(int countOfEmpty, int sum, List<int> availableNumbers, List<Coordinate> key)
    {
        if (countOfEmpty == 0)
            if (sum != _killerValues[key])
                return false;
        List<int> minNumbers = new List<int>(availableNumbers);
        minNumbers.Sort();
        List<int> maxNumbers = new List<int>(availableNumbers);
        maxNumbers.Sort();
        maxNumbers.Reverse();
        int sumMin = sum;
        int sumMax = sum;

        for (int i = 0; i < countOfEmpty; i++)
        {
            sumMin += minNumbers[i];
            sumMax += maxNumbers[i];
        }

        return !(sumMin > _killerValues[key] || sumMax < _killerValues[key]);
    }


    public bool KillerSolve()
    {
        foreach (var key in _killerValuesSorted.Keys)
        {
            int sum = 0;
            int count = key.Count;
            List<int> availableNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var coordinate in key)
            {
                if (Board[coordinate.X, coordinate.Y] == 0)
                {
                    for (int number = 1; number <= Size; number++)
                    {
                        if (availableNumbers.Contains(number))
                        {
                            availableNumbers.Remove(number);
                            sum += number;
                            if (AreKillerValuesValid(count - 1, sum, availableNumbers, key))
                            {
                                if (base.IsValidNumber(number, coordinate.X, coordinate.Y, Board))
                                {
                                    Board[coordinate.X, coordinate.Y] = number;

                                    if (KillerSolve())
                                        return true;
                                    else
                                        Board[coordinate.X, coordinate.Y] = 0;
                                }
                            }
                            sum -= number;
                            availableNumbers.Add(number);
                        }
                    }

                    return false;
                }
                else
                {
                    sum += Board[coordinate.X, coordinate.Y];
                    availableNumbers.Remove(Board[coordinate.X, coordinate.Y]);
                    count--;
                }
            }
        }

        return true;
    }
}
