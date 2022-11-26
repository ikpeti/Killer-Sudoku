using Sudoku.Api.Types;

namespace Sudoku.Api.Solvers;
public class NewSolver
{
    public int Size { get; }
    public List<Field> Fields { get; }
    public NewSolver(int size, int[,]? sudoku = null)
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
        bool finished = false;
        ReduceLists(Fields);
        while (!finished)
        {
            var solvedFields = NewSolvedFields();
            if (solvedFields.Count == 0)
                finished = true;
            else
                ReduceLists(solvedFields);
        }

        foreach (var field in Fields)
        {
            if (field.Value == 0)
                return false;
        }
        return true;
    }

    private void ReduceLists(List<Field> FinishedFields)
    {
        foreach (var field in FinishedFields)
        {
            if (field.Value == 0)
                continue;
            ReducePossibleFieldsListByNumber(field);
        }
    }

    private void ReduceOtherRule()
    {
        for (int i = 0; i < Size; i++)
        {
            ReduceRow(i);
            ReduceColumn(i);
            ReduceBox(i);
        }
    }

    private void ReduceRow(int i)
    {
        var possibleNumbers = new List<int>();
        foreach (var field in Fields)
        {
            if (field.Coordinate.X == i && field.Value == 0)
            {
                possibleNumbers.AddRange(field.PossibleValues);
            }
        }

        var g = possibleNumbers.GroupBy(i => i);

        int num = 0;
        foreach (var grp in g)
        {
            if (grp.Count() == 1)
                num = grp.Key;
        }

        if (num != 0)
        {
            foreach (var field in Fields)
            {
                if (field.Coordinate.X == i && field.Value == 0 && field.PossibleValues.Contains(num))
                {
                    field.ReduceValues(num);
                }
            }
        }
    }

    private List<Field> NewSolvedFields()
    {
        var result = new List<Field>();
        foreach (var field in Fields)
        {
            if (field.PossibleValues.Count == 1)
            {
                field.SetValue();
                result.Add(field);
            }
        }
        return result;
    }

    private void ReducePossibleFieldsListByNumber(Field f)
    {
        foreach (var field in Fields)
        {
            if (field == f)
                continue;
            if (IsInRow(f, field) || IsInColumn(f, field) || IsInBox(f, field))
            {
                field.ReduceValues(f.Value);
            }
        }
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

    private int BoxNumber(Field f)
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
