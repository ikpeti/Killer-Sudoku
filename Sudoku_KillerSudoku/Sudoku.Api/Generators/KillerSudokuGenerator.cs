using Sudoku.Api.Solvers;

namespace Sudoku.Api.Generators;
public class KillerSudokuGenerator
{
    private readonly ISudokuBoard sudokuBoard;
    private readonly ISudokuGenerator sudokuGenerator;
    private Random random;
    public List<List<int>> KillerFields { get; }
    public List<int> KillerValues { get; set; }

    public KillerSudokuGenerator(ISudokuBoard sudokuBoard, ISudokuGenerator sudokuGenerator)
    {
        this.sudokuBoard = sudokuBoard;
        this.sudokuGenerator = sudokuGenerator;
        this.random = new Random();
        KillerFields = new List<List<int>>();
        KillerValues = new List<int>();
    }

    public ISudokuBoard GetBoard()
    {
        return sudokuBoard;
    }

    public void Generate()
    {
        sudokuBoard.Init(sudokuGenerator.GenerateRookLayout());
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

                    var number = random.Next(0, 2);
                    while (!possibilities[number])
                    {
                        number = random.Next(0, 2);
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
}