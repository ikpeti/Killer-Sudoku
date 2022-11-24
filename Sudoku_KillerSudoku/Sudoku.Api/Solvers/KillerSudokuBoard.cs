using Sudoku.Api.Types;

namespace Sudoku.Api.Solvers;
public class KillerSudokuBoard : SudokuBoard
{
    private Dictionary<List<Coordinate>, int> _killerValues;
    private SortedList<List<Coordinate>, int> _killerValuesSorted;
    public KillerSudokuBoard()
    {
        _killerValues = new Dictionary<List<Coordinate>, int>();
        _killerValuesSorted = new SortedList<List<Coordinate>, int>(new KillerComparer());

        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 0 },
            new Coordinate
                { X = 1, Y = 0 }
        }, 12);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 1 },
            new Coordinate
                { X = 0, Y = 2 },
            new Coordinate
                { X = 1, Y = 2 },
            new Coordinate
                { X = 1, Y = 3 }
        }, 16);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 3 },
            new Coordinate
                { X = 0, Y = 4 },
            new Coordinate
                { X = 0, Y = 5 },
            new Coordinate
                { X = 1, Y = 4 }
        }, 21);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 6 },
            new Coordinate
                { X = 1, Y = 5 },
            new Coordinate
                { X = 1, Y = 6 }
        }, 18);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 7 },
            new Coordinate
                { X = 1, Y = 7 },
            new Coordinate
                { X = 2, Y = 7 },
            new Coordinate
                { X = 3, Y = 7 }
        }, 26);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 8 },
            new Coordinate
                { X = 1, Y = 8 }
        }, 5);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 1, Y = 1 },
            new Coordinate
                { X = 2, Y = 0 },
            new Coordinate
                { X = 2, Y = 1 },
            new Coordinate
                { X = 2, Y = 2 }
        }, 21);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 3 },
            new Coordinate
                { X = 3, Y = 1 },
            new Coordinate
                { X = 3, Y = 2 },
            new Coordinate
                { X = 3, Y = 3 }
        }, 23);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 4 },
            new Coordinate
                { X = 3, Y = 4 },
            new Coordinate
                { X = 4, Y = 4 }
        }, 13);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 5 },
            new Coordinate
                { X = 2, Y = 6 }
        }, 3);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 8 },
            new Coordinate
                { X = 3, Y = 8 }
        }, 17);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 0 },
            new Coordinate
                { X = 4, Y = 0 }
        }, 9);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 5 },
            new Coordinate
                { X = 3, Y = 6 }
        }, 5);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 1 },
            new Coordinate
                { X = 5, Y = 0 },
            new Coordinate
                { X = 5, Y = 1 },
            new Coordinate
                { X = 5, Y = 2 }
        }, 14);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 2 },
            new Coordinate
                { X = 4, Y = 3 },
            new Coordinate
                { X = 5, Y = 3 }
        }, 16);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 5 },
            new Coordinate
                { X = 5, Y = 5 },
            new Coordinate
                { X = 6, Y = 5 }
        }, 17);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 6 },
            new Coordinate
                { X = 4, Y = 7 },
            new Coordinate
                { X = 4, Y = 8 }
        }, 14);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 4 },
            new Coordinate
                { X = 6, Y = 3 },
            new Coordinate
                { X = 6, Y = 4 },
            new Coordinate
                { X = 7, Y = 3 }
        }, 26);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 6 },
            new Coordinate
                { X = 6, Y = 6 }
        }, 10);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 7 },
            new Coordinate
                { X = 5, Y = 8 }
        }, 7);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 0 },
            new Coordinate
                { X = 6, Y = 1 },
            new Coordinate
                { X = 6, Y = 2 }
        }, 10);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 7 },
            new Coordinate
                { X = 6, Y = 8 }
        }, 15);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 0 },
            new Coordinate
                { X = 7, Y = 1 },
            new Coordinate
                { X = 7, Y = 2 }
        }, 12);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 4 },
            new Coordinate
                { X = 8, Y = 4 }
        }, 7);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 5 },
            new Coordinate
                { X = 8, Y = 5 },
            new Coordinate
                { X = 8, Y = 6 }
        }, 15);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 6 },
            new Coordinate
                { X = 7, Y = 7 },
            new Coordinate
                { X = 7, Y = 8 }
        }, 20);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 0 },
            new Coordinate
                { X = 8, Y = 1 }
        }, 17);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 2 },
            new Coordinate
                { X = 8, Y = 3 }
        }, 13);
        _killerValues.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 7 },
            new Coordinate
                { X = 8, Y = 8 }
        }, 3);

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
