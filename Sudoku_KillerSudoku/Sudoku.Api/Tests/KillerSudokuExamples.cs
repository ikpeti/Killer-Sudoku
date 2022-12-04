using Sudoku.Api.Types;

namespace Sudoku.Api.Tests;
public static class KillerSudokuExamples
{
    public static KillerValueModel FirstExample
    {
        get
        {
            var result = new KillerValueModel();
            result.KillerFields = new List<List<int>>();
            result.KillerValues = new List<int>();
            result.KillerFields.AddRange(new List<List<int>>
            {
                new List<int>
                {
                    1, 10
                },
                new List<int>
                {
                    2, 3, 12, 13
                },
                new List<int>
                {
                    4, 5, 6, 14
                },
                new List<int>
                {
                    7, 15, 16
                },
                new List<int>
                {
                    8, 17, 26, 35
                },
                new List<int>
                {
                    9, 18
                },
                new List<int>
                {
                    11, 19, 20, 21
                },
                new List<int>
                {
                    22, 29, 30, 31
                },
                new List<int>
                {
                    23, 32, 41
                },
                new List<int>
                {
                    24, 25
                },
                new List<int>
                {
                    27, 36
                },
                new List<int>
                {
                    28, 37
                },
                new List<int>
                {
                    33, 34
                },
                new List<int>
                {
                    38, 46, 47, 48
                },
                new List<int>
                {
                    39, 40, 49
                },
                new List<int>
                {
                    42, 51, 60
                },
                new List<int>
                {
                    43, 44, 45
                },
                new List<int>
                {
                    50, 58, 59, 67
                },
                new List<int>
                {
                    52, 61
                },
                new List<int>
                {
                    53, 54
                },
                new List<int>
                {
                    55, 56, 57
                },
                new List<int>
                {
                    62, 63
                },
                new List<int>
                {
                    64, 65, 66
                },
                new List<int>
                {
                    68, 77
                },
                new List<int>
                {
                    69, 78, 79
                },
                new List<int>
                {
                    70, 71, 72
                },
                new List<int>
                {
                    73, 74
                },
                new List<int>
                {
                    75, 76
                },
                new List<int>
                {
                    80, 81
                }
            });
            result.KillerValues.AddRange(new List<int>
            {
                12, 16, 21, 18, 26, 5, 21, 23, 13, 3, 17, 9, 5, 14, 16, 17, 14, 26, 10, 7, 10, 15, 12, 7, 15, 20, 17, 13, 3
            });
            return result;
        }
    }

    public static Dictionary<List<Coordinate>, int> RecursionFirstExample
    {
        get
        {
            Dictionary<List<Coordinate>, int> result = new Dictionary<List<Coordinate>, int>();
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 0 },
            new Coordinate
                { X = 1, Y = 0 }
        }, 12);
            result.Add(new List<Coordinate>
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
            result.Add(new List<Coordinate>
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
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 6 },
            new Coordinate
                { X = 1, Y = 5 },
            new Coordinate
                { X = 1, Y = 6 }
        }, 18);
            result.Add(new List<Coordinate>
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
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 8 },
            new Coordinate
                { X = 1, Y = 8 }
        }, 5);
            result.Add(new List<Coordinate>
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
            result.Add(new List<Coordinate>
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
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 4 },
            new Coordinate
                { X = 3, Y = 4 },
            new Coordinate
                { X = 4, Y = 4 }
        }, 13);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 5 },
            new Coordinate
                { X = 2, Y = 6 }
        }, 3);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 8 },
            new Coordinate
                { X = 3, Y = 8 }
        }, 17);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 0 },
            new Coordinate
                { X = 4, Y = 0 }
        }, 9);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 5 },
            new Coordinate
                { X = 3, Y = 6 }
        }, 5);
            result.Add(new List<Coordinate>
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
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 2 },
            new Coordinate
                { X = 4, Y = 3 },
            new Coordinate
                { X = 5, Y = 3 }
        }, 16);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 5 },
            new Coordinate
                { X = 5, Y = 5 },
            new Coordinate
                { X = 6, Y = 5 }
        }, 17);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 6 },
            new Coordinate
                { X = 4, Y = 7 },
            new Coordinate
                { X = 4, Y = 8 }
        }, 14);
            result.Add(new List<Coordinate>
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
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 6 },
            new Coordinate
                { X = 6, Y = 6 }
        }, 10);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 7 },
            new Coordinate
                { X = 5, Y = 8 }
        }, 7);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 0 },
            new Coordinate
                { X = 6, Y = 1 },
            new Coordinate
                { X = 6, Y = 2 }
        }, 10);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 7 },
            new Coordinate
                { X = 6, Y = 8 }
        }, 15);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 0 },
            new Coordinate
                { X = 7, Y = 1 },
            new Coordinate
                { X = 7, Y = 2 }
        }, 12);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 4 },
            new Coordinate
                { X = 8, Y = 4 }
        }, 7);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 5 },
            new Coordinate
                { X = 8, Y = 5 },
            new Coordinate
                { X = 8, Y = 6 }
        }, 15);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 6 },
            new Coordinate
                { X = 7, Y = 7 },
            new Coordinate
                { X = 7, Y = 8 }
        }, 20);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 0 },
            new Coordinate
                { X = 8, Y = 1 }
        }, 17);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 2 },
            new Coordinate
                { X = 8, Y = 3 }
        }, 13);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 7 },
            new Coordinate
                { X = 8, Y = 8 }
        }, 3);
            return result;
        }
    }

    public static Dictionary<List<Coordinate>, int> RecursionSecondExample
    {
        get
        {
            Dictionary<List<Coordinate>, int> result = new Dictionary<List<Coordinate>, int>();
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 0 },
            new Coordinate
                { X = 1, Y = 0 },
            new Coordinate
                { X = 1, Y = 1 },
            new Coordinate
                { X = 2, Y = 1 }
        }, 17);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 1 },
            new Coordinate
                { X = 0, Y = 2 }
        }, 13);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 3 },
            new Coordinate
                { X = 1, Y = 3 },
            new Coordinate
                { X = 1, Y = 4 }
        }, 20);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 4 },
            new Coordinate
                { X = 0, Y = 5 }
        }, 11);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 6 },
            new Coordinate
                { X = 1, Y = 6 },
            new Coordinate
                { X = 2, Y = 6 }
        }, 18);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 7 },
            new Coordinate
                { X = 1, Y = 7 },
            new Coordinate
                { X = 2, Y = 7 },
            new Coordinate
                { X = 2, Y = 8 }
        }, 19);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 8 },
            new Coordinate
                { X = 1, Y = 8 }
        }, 8);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 1, Y = 2 },
            new Coordinate
                { X = 2, Y = 2 }
        }, 10);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 1, Y = 5 },
            new Coordinate
                { X = 2, Y = 3 },
            new Coordinate
                { X = 2, Y = 4 },
            new Coordinate
                { X = 2, Y = 5 }
        }, 14);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 0 },
            new Coordinate
                { X = 3, Y = 0 }
        }, 13);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 1 },
            new Coordinate
                { X = 4, Y = 1 },
            new Coordinate
                { X = 4, Y = 2 },
            new Coordinate
                { X = 4, Y = 3 }
        }, 11);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 2 },
            new Coordinate
                { X = 3, Y = 3 }
        }, 11);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 4 },
            new Coordinate
                { X = 4, Y = 4 }
        }, 16);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 5 },
            new Coordinate
                { X = 4, Y = 5 }
        }, 12);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 6 },
            new Coordinate
                { X = 3, Y = 7 },
            new Coordinate
                { X = 3, Y = 8 },
            new Coordinate
                { X = 4, Y = 8 }
        }, 19);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 0 },
            new Coordinate
                { X = 5, Y = 0 }
        }, 7);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 6 },
            new Coordinate
                { X = 4, Y = 7 }
        }, 9);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 1 },
            new Coordinate
                { X = 5, Y = 2 }
        }, 16);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 3 },
            new Coordinate
                { X = 5, Y = 4 }
        }, 7);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 5 },
            new Coordinate
                { X = 5, Y = 6 },
            new Coordinate
                { X = 6, Y = 5 }
        }, 7);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 7 },
            new Coordinate
                { X = 5, Y = 8 },
            new Coordinate
                { X = 6, Y = 8 }
        }, 15);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 0 },
            new Coordinate
                { X = 7, Y = 0 },
            new Coordinate
                { X = 8, Y = 0 }
        }, 12);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 1 },
            new Coordinate
                { X = 6, Y = 2 }
        }, 11);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 3 },
            new Coordinate
                { X = 7, Y = 2 },
            new Coordinate
                { X = 7, Y = 3 }
        }, 17);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 4 },
            new Coordinate
                { X = 7, Y = 4 },
            new Coordinate
                { X = 8, Y = 4 }
        }, 10);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 6 },
            new Coordinate
                { X = 6, Y = 7 }
        }, 15);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 1 },
            new Coordinate
                { X = 8, Y = 1 }
        }, 12);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 5 },
            new Coordinate
                { X = 7, Y = 6 },
            new Coordinate
                { X = 8, Y = 5 },
            new Coordinate
                { X = 8, Y = 6 }
        }, 27);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 7 },
            new Coordinate
                { X = 8, Y = 7 }
        }, 4);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 8 },
            new Coordinate
                { X = 8, Y = 8 }
        }, 13);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 2 },
            new Coordinate
                { X = 8, Y = 3 }
        }, 11);
            return result;
        }
    }
    public static Dictionary<List<Coordinate>, int> RecursionThirdExample
    {
        get
        {
            Dictionary<List<Coordinate>, int> result = new Dictionary<List<Coordinate>, int>();
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 0 },
            new Coordinate
                { X = 1, Y = 0 },
            new Coordinate
                { X = 1, Y = 1 },
            new Coordinate
                { X = 1, Y = 2 },
            new Coordinate
                { X = 2, Y = 1 }
        }, 26);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 1 },
            new Coordinate
                { X = 0, Y = 2 }
        }, 5);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 3 },
            new Coordinate
                { X = 0, Y = 4 },
            new Coordinate
                { X = 0, Y = 5 }
        }, 23);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 6 },
            new Coordinate
                { X = 0, Y = 7 }
        }, 8);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 0, Y = 8 },
            new Coordinate
                { X = 1, Y = 8 }
        }, 14);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 1, Y = 3 },
            new Coordinate
                { X = 1, Y = 4 },
            new Coordinate
                { X = 2, Y = 4 }
        }, 10);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 1, Y = 5 },
            new Coordinate
                { X = 1, Y = 6 }
        }, 5);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 1, Y = 7 },
            new Coordinate
                { X = 2, Y = 7 },
            new Coordinate
                { X = 2, Y = 8 }
        }, 18);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 0 },
            new Coordinate
                { X = 3, Y = 0 },
            new Coordinate
                { X = 3, Y = 1 }
        }, 15);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 2 },
            new Coordinate
                { X = 2, Y = 3 },
            new Coordinate
                { X = 3, Y = 2 },
            new Coordinate
                { X = 3, Y = 3 }
        }, 22);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 5 },
            new Coordinate
                { X = 3, Y = 5 }
        }, 9);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 2, Y = 6 },
            new Coordinate
                { X = 3, Y = 6 }
        }, 12);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 4 },
            new Coordinate
                { X = 4, Y = 4 }
        }, 7);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 3, Y = 7 },
            new Coordinate
                { X = 3, Y = 8 },
            new Coordinate
                { X = 4, Y = 7 },
            new Coordinate
                { X = 4, Y = 8 }
        }, 18);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 0 },
            new Coordinate
                { X = 4, Y = 1 },
            new Coordinate
                { X = 5, Y = 1 },
            new Coordinate
                { X = 5, Y = 2 }
        }, 23);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 2 },
            new Coordinate
                { X = 4, Y = 3 }
        }, 13);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 4, Y = 5 },
            new Coordinate
                { X = 4, Y = 6 },
            new Coordinate
                { X = 5, Y = 5 },
            new Coordinate
                { X = 5, Y = 6 }
        }, 23);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 0 },
            new Coordinate
                { X = 6, Y = 0 }
        }, 12);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 3 },
            new Coordinate
                { X = 5, Y = 4 }
        }, 10);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 5, Y = 7 },
            new Coordinate
                { X = 5, Y = 8 },
            new Coordinate
                { X = 6, Y = 7 }
        }, 8);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 1 },
            new Coordinate
                { X = 6, Y = 2 },
            new Coordinate
                { X = 7, Y = 2 }
        }, 17);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 3 },
            new Coordinate
                { X = 6, Y = 4 }
        }, 15);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 5 },
            new Coordinate
                { X = 7, Y = 4 },
            new Coordinate
                { X = 7, Y = 5 }
        }, 7);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 6 },
            new Coordinate
                { X = 7, Y = 6 }
        }, 11);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 6, Y = 8 },
            new Coordinate
                { X = 7, Y = 8 },
            new Coordinate
                { X = 8, Y = 8 }
        }, 14);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 0 },
            new Coordinate
                { X = 8, Y = 0 }
        }, 8);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 1 },
            new Coordinate
                { X = 8, Y = 1 },
            new Coordinate
                { X = 8, Y = 2 }
        }, 11);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 3 },
            new Coordinate
                { X = 8, Y = 3 },
            new Coordinate
                { X = 8, Y = 4 }
        }, 14);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 7, Y = 7 },
            new Coordinate
                { X = 8, Y = 7 }
        }, 17);
            result.Add(new List<Coordinate>
        {
            new Coordinate
                { X = 8, Y = 5 },
            new Coordinate
                { X = 8, Y = 6 }
        }, 10);
            return result;
        }
    }
}

public class KillerValueModel
{
    public List<List<int>> KillerFields { get; set; } = default!;
    public List<int> KillerValues { get; set; } = default!;
}