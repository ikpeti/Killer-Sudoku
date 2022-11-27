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
}

public class KillerValueModel
{
    public List<List<int>> KillerFields { get; set; } = default!;
    public List<int> KillerValues { get; set; } = default!;
}