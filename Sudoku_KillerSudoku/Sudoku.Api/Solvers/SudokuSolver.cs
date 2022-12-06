using Sudoku.Api.Types;

namespace Sudoku.Api.Solvers;
public class SudokuSolver
{
    public int Size { get; }
    public List<Field> Fields { get; }
    public List<List<Field>> Solutions { get; }
    public SudokuSolver(int size, int[,]? sudoku = null)
    {
        Size = size;
        Fields = new List<Field>();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (sudoku != null)
                    Fields.Add(new Field(i, j, sudoku[i, j]));
                else
                    Fields.Add(new Field(i, j));
            }
        }
        Solutions = new List<List<Field>>();
    }

    public List<int> GetSolution()
    {
        var result = new List<int>();
        foreach (var field in Fields)
        {
            result.Add(field.Value);
        }

        return result;
    }

    public bool Solve()
    {
        InitialReducing();
        ReduceLists(Fields);

        var result = FillFields(null);
        if (result && Solutions.Count == 1)
        {
            Fields.Clear();
            Fields.AddRange(Solutions[0]);
            return true;
        }

        return false;
    }

    private bool FillFields(Field? solvedField)
    {
        while (true)
        {
            if (WrongAlready())
                return false;
            if (ReduceByNewNumber(solvedField) || CheckRowsColumnsAndBoxes() || OtherKillerRules())
            {
                solvedField = NewSolvedField();
            }
            else
            {
                return FillFirstFieldRandomly();
            }
        }
    }

    private bool FillFirstFieldRandomly()
    {
        foreach (var field in Fields)
        {
            if (field.Value == 0)
            {
                var result = false;
                var tryValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                tryValues.RemoveAll(x => !field.PossibleValues.Contains(x));
                foreach (var value in tryValues)
                {
                    var boardState = SaveState();
                    var actualField = Fields.Find(x => x.Coordinate.Equals(field.Coordinate.X, field.Coordinate.Y));
                    if (actualField == null)
                        throw new Exception();
                    actualField.PossibleValues.RemoveAll(x => x != value);
                    if (FillFields(NewSolvedField()))
                    {
                        result = true;
                        if (Solutions.Count > 1)
                            return true;
                    }
                    Fields.Clear();
                    Fields.AddRange(boardState);
                    RefreshKillerValues();
                }
                return result;
            }
        }

        Solutions.Add(SaveState());

        return true;
    }

    private bool WrongAlready()
    {
        var wrongItems = Fields.Where(x => x.Value == 0 && x.PossibleValues.Count == 0).FirstOrDefault();
        return wrongItems != null;
    }

    protected virtual void RefreshKillerValues() { }

    private List<Field> SaveState()
    {
        var result = new List<Field>();
        foreach (var field in Fields)
        {
            var newField = new Field(field.Coordinate.X, field.Coordinate.Y);
            newField.SetValues(field.Value, field.PossibleValues);
            result.Add(newField);
        }
        return result;
    }

    protected virtual bool OtherKillerRules()
    {
        return false;
    }

    protected virtual void InitialReducing() { }

    private bool ReduceLists(List<Field> FinishedFields)
    {
        var result = false;
        foreach (var field in FinishedFields)
        {
            if (field.Value == 0)
                continue;
            if (ReduceByNewNumber(field))
                result = true;
        }

        return result;
    }

    private bool CheckRowsColumnsAndBoxes()
    {
        for (int i = 0; i < Size; i++)
        {
            if (FindSingleElement(i, (x, y) => y.Coordinate.X == x) ||
            FindSingleElement(i, (x, y) => y.Coordinate.Y == x) ||
            FindSingleElement(i, (x, y) => BoxNumber(y) == x))
            {
                return true;
            }
        }
        return false;
    }

    private bool FindSingleElement(int i, Func<int, Field, bool> pred)
    {
        var possibleNumbers = new List<int>();
        foreach (var field in Fields)
        {
            if (pred(i, field) && field.Value == 0)
            {
                possibleNumbers.AddRange(field.PossibleValues);
            }
        }

        int num = GetSingleElement(possibleNumbers);

        if (num != 0)
        {
            ReduceOtherRuleOnePossibleElement(i, num, pred);
            return true;
        }

        return false;
    }

    private int GetSingleElement(List<int> possibleNumbers)
    {
        var g = possibleNumbers.GroupBy(i => i);

        int num = 0;
        foreach (var grp in g)
        {
            if (grp.Count() == 1)
                num = grp.Key;
        }

        return num;
    }

    private void ReduceOtherRuleOnePossibleElement(int i, int num, Func<int, Field, bool> pred)
    {
        foreach (var field in Fields)
        {
            if (pred(i, field) && field.Value == 0 && field.PossibleValues.Contains(num))
            {
                field.KeepValue(num);
            }
        }
    }

    private Field? NewSolvedField()
    {
        foreach (var field in Fields)
        {
            if (field.PossibleValues.Count == 1)
            {
                field.SetValue();
                ReduceKillerFields(field);
                return field;
            }
        }
        return null;
    }

    protected virtual void ReduceKillerFields(Field field) { }

    private bool ReduceByNewNumber(Field? f)
    {
        if (f == null)
            return false;
        var result = false;
        foreach (var field in Fields)
        {
            if (field == f)
                continue;
            if (IsInRow(f, field) || IsInColumn(f, field) || IsInBox(f, field))
            {
                if (field.RemoveValue(f.Value))
                    result = true;
            }
        }

        return result;
    }

    private bool IsInRow(Field f1, Field f2)
    {
        return f1.Coordinate.X == f2.Coordinate.X;
    }

    private bool IsInColumn(Field f1, Field f2)
    {
        return f1.Coordinate.Y == f2.Coordinate.Y;
    }

    private bool IsInBox(Field f1, Field f2)
    {
        return BoxNumber(f1) == BoxNumber(f2);
    }

    protected int BoxNumber(Field f)
    {
        var boxSize = (int)Math.Sqrt(Size);
        int boxNumber = 1;
        for (int i = 0; i < Size; i += boxSize)
        {
            for (int j = 0; j < Size; j += boxSize)
            {
                if (f.Coordinate.X <= i + 2 && f.Coordinate.Y <= j + 2)
                    return boxNumber;
                boxNumber++;
            }
        }
        return 0;
    }

    public void Print()
    {
        int i = 1;
        foreach (var field in Fields)
        {
            if (i == 28 || i == 55)
                Console.WriteLine("---------------------");
            if (i == 4 || i == 7 || i == 13 || i == 16 || i == 22 || i == 25 || i == 31 || i == 34 || i == 40 || i == 43 || i == 49 || i == 52 || i == 58 || i == 61 || i == 67 || i == 70 || i == 76 || i == 79)
                Console.Write("| ");
            Console.Write(field.Value + " ");
            if (i == 9 || i == 18 || i == 27 || i == 36 || i == 45 || i == 54 || i == 63 || i == 72 || i == 81)
                Console.WriteLine();
            i++;
        }
        Console.WriteLine();
    }
}
