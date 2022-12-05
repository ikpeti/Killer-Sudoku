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

    public static KillerValueModel SecondExample
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
                    1, 10, 11, 20
                },
                new List<int>
                {
                    2, 3
                },
                new List<int>
                {
                    4, 13, 14
                },
                new List<int>
                {
                    5, 6
                },
                new List<int>
                {
                    7, 16, 25
                },
                new List<int>
                {
                    8, 17, 26, 27
                },
                new List<int>
                {
                    9, 18
                },
                new List<int>
                {
                    12, 21
                },
                new List<int>
                {
                    15, 22, 23, 24
                },
                new List<int>
                {
                    19, 28
                },
                new List<int>
                {
                    29, 38, 39, 40
                },
                new List<int>
                {
                    30, 31
                },
                new List<int>
                {
                    32, 41
                },
                new List<int>
                {
                    33, 42
                },
                new List<int>
                {
                    34, 35, 36, 45
                },
                new List<int>
                {
                    37, 46
                },
                new List<int>
                {
                    43, 44
                },
                new List<int>
                {
                    47, 48
                },
                new List<int>
                {
                    49, 50
                },
                new List<int>
                {
                    51, 52, 60
                },
                new List<int>
                {
                    53, 54, 63
                },
                new List<int>
                {
                    55, 64, 73
                },
                new List<int>
                {
                    56, 57
                },
                new List<int>
                {
                    58, 66, 67
                },
                new List<int>
                {
                    59, 68, 77
                },
                new List<int>
                {
                    61, 62
                },
                new List<int>
                {
                    65, 74
                },
                new List<int>
                {
                    69, 70, 78, 79
                },
                new List<int>
                {
                    71, 80
                },
                new List<int>
                {
                    72, 81
                },
                new List<int>
                {
                    75, 76
                }
            });
            result.KillerValues.AddRange(new List<int>
            {
                17, 13, 20, 11, 18, 19, 8, 10, 14, 13, 11, 11, 16, 12, 19, 7, 9, 16, 7, 7, 15, 12, 11, 17, 10, 15, 12, 27, 4, 13, 11
            });
            return result;
        }
    }
    public static KillerValueModel ThirdExample
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
                    1, 10, 11, 12, 20
                },
                new List<int>
                {
                    2, 3
                },
                new List<int>
                {
                    4, 5, 6
                },
                new List<int>
                {
                    7, 8
                },
                new List<int>
                {
                    9, 18
                },
                new List<int>
                {
                    13, 14, 23
                },
                new List<int>
                {
                    15, 16
                },
                new List<int>
                {
                    17, 26, 27
                },
                new List<int>
                {
                    19, 28, 29
                },
                new List<int>
                {
                    21, 22, 30, 31
                },
                new List<int>
                {
                    24, 33
                },
                new List<int>
                {
                    25, 34
                },
                new List<int>
                {
                    32, 41
                },
                new List<int>
                {
                    35, 36, 44, 45
                },
                new List<int>
                {
                    37, 38, 47, 48
                },
                new List<int>
                {
                    39, 40
                },
                new List<int>
                {
                    42, 43, 51, 52
                },
                new List<int>
                {
                    46, 55
                },
                new List<int>
                {
                    49, 50
                },
                new List<int>
                {
                    53, 54, 62
                },
                new List<int>
                {
                    56, 57, 66
                },
                new List<int>
                {
                    58, 59
                },
                new List<int>
                {
                    60, 68, 69
                },
                new List<int>
                {
                    61, 70
                },
                new List<int>
                {
                    63, 72, 81
                },
                new List<int>
                {
                    64, 73
                },
                new List<int>
                {
                    65, 74, 75
                },
                new List<int>
                {
                    67, 76, 77
                },
                new List<int>
                {
                    71, 80
                },
                new List<int>
                {
                    78, 79
                }
            });
            result.KillerValues.AddRange(new List<int>
            {
                26, 5, 23, 8, 14, 10, 5, 18, 15, 22, 9, 12, 7, 18, 23, 13, 23, 12, 10, 8, 17, 15, 7, 11, 14, 8, 11, 14, 17, 10
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