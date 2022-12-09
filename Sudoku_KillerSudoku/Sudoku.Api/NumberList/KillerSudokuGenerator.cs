using Sudoku.Api.Recursive;
using Sudoku.Api.Types;

namespace Sudoku.Api.NumberList;
public class KillerSudokuGenerator
{
    private readonly SudokuBoard sudokuBoard;
    private Random random;
    public List<List<int>> KillerFields { get; }
    public List<int> KillerValues { get; private set; }
    public int[,] KillerBoard { get; }
    public int Size { get; set; }

    public KillerSudokuGenerator()
    {
        sudokuBoard = new SudokuBoard();
        random = new Random();
        KillerFields = new List<List<int>>();
        KillerValues = new List<int>();
        KillerBoard = new int[sudokuBoard.Size, sudokuBoard.Size];
        Size = sudokuBoard.Size;
        for (int i = 0; i < sudokuBoard.Size; i++)
        {
            for (int j = 0; j < sudokuBoard.Size; j++)
            {
                KillerBoard[i, j] = 0;
            }
        }
    }

    public List<int> Generate()
    {
        KillerRulesGenerate();

        var killerSolver = new KillerSolver(9, KillerFields, KillerValues);

        while (!killerSolver.Solve())
        {
            if (!FillAField(killerSolver.IndexOfLastChange))
            {
                Reset();
                KillerRulesGenerate();
            }
            killerSolver = new KillerSolver(9, KillerFields, KillerValues, KillerBoard);
        }

        return killerSolver.GetSolution();
    }

    private bool FillAField(int index)
    {
        if (index == 0)
            return false;
        int x = index / Size;
        int y = index % Size;
        if (y == 0)
        {
            x -= 1;
            y = 9;
        }
        y -= 1;

        KillerBoard[x, y] = sudokuBoard.Board[x, y];
        return true;
    }

    private void KillerRulesGenerate()
    {
        sudokuBoard.Init(new RookLayoutGenerator(Size).GenerateRookLayout());
        sudokuBoard.Solve();

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (sudokuBoard.Board[i, j] != 0)
                {
                    bool[] possibilities = new bool[3] { true, true, true };
                    if (i == 0)
                        possibilities[1] = false;
                    if (j == 0)
                        possibilities[2] = false;
                    if (i != 0 && CheckKillerFields(i - 1, j, 5))
                        possibilities[1] = false;
                    if (j != 0 && CheckKillerFields(i, j - 1, 5))
                        possibilities[2] = false;
                    if (i != 0 && CheckKillerFields(i - 1, j, 1))
                    {
                        possibilities[1] = true;
                        possibilities[2] = false;
                        possibilities[0] = false;
                    }

                    var number = random.Next(0, 3);
                    while (!possibilities[number])
                    {
                        number = random.Next(0, 3);
                    }

                    FinishField(i, j, sudokuBoard.Board[i, j], number);
                }
            }
        }
    }

    private void FinishField(int i, int j, int value, int number)
    {
        var index = i * 9 + j + 1;
        switch (number)
        {
            case 0:
                KillerFields.Add(new List<int> { index });
                KillerValues.Add(value);
                break;
            case 1:
                AddToExistingGroup(index, index - 9, value);
                break;
            case 2:
                AddToExistingGroup(index, index - 1, value);
                break;
            default:
                break;
        }
    }

    private void AddToExistingGroup(int index, int i, int value)
    {
        var group = KillerFields.Find(x => x.Contains(i));
        var indx = KillerFields.IndexOf(group!);
        group!.Add(index);
        KillerValues[indx] += value;
    }

    private bool CheckKillerFields(int i, int j, int num)
    {
        var index = i * 9 + j + 1;
        foreach (var killer in KillerFields)
        {
            if (killer.Contains(index))
            {
                if (killer.Count == num)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Reset()
    {
        KillerFields.Clear();
        KillerValues.Clear();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                KillerBoard[i, j] = 0;
            }
        }
    }
}