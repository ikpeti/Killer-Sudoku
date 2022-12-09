using Sudoku.Api.Types;

namespace Sudoku.Api.NumberList;
public class KillerSolver : SudokuSolver
{
    private Dictionary<List<Field>, int> _killerValues;
    public KillerSolver(int size, List<List<int>> killerFields, List<int> killerValues, int[,]? sudoku = null) : base(size, sudoku)
    {
        _killerValues = new Dictionary<List<Field>, int>();
        int x = 0;
        foreach (var killer in killerFields)
        {
            var key = new List<Field>();
            foreach (var i in killer)
            {
                key.Add(Fields[i - 1]);
            }
            _killerValues.Add(key, killerValues[x++]);
        }
    }

    protected override void InitialReducing()
    {
        foreach (var killer in _killerValues)
        {
            KillerReducingFromSum(killer.Key, killer.Value);
        }
    }

    protected override bool OtherKillerRules()
    {
        return CheckSums();
    }

    private bool KillerReducingFromSum(List<Field> fields, int value)
    {
        if (fields == null)
            return false;

        var emptyFields = fields.Where(x => x.Value == 0).ToList();
        if (emptyFields == null || emptyFields.Count == 0)
            return false;

        var remainingValue = value - fields.Sum(x => x.Value);

        var result = false;
        var min = 0;
        var max = 0;
        for (int i = 1; i < emptyFields.Count; i++)
        {
            min += i;
            max += (10 - i);
        }
        for (int i = (remainingValue - min) + 1; i < 10; i++)
        {
            foreach (var field in emptyFields)
            {
                if (field.RemoveValue(i))
                    result = true;
            }
        }
        for (int i = (remainingValue - max) - 1; i > 0; i--)
        {
            foreach (var field in emptyFields)
            {
                if (field.RemoveValue(i))
                    result = true;
            }
        }
        return result;
    }

    private bool CheckSums()
    {
        var result = false;
        for (int i = 0; i < Size; i++)
        {
            if (
            CheckSumOfOneElement(i, (x, y) => y.Coordinate.X == x) ||
            CheckSumOfOneElement(i, (x, y) => y.Coordinate.Y == x) ||
            CheckSumOfOneElement(i, (x, y) => BoxNumber(y) == x))
                result = true;
        }
        return result;
    }

    private bool CheckSumOfOneElement(int i, Func<int, Field, bool> pred)
    {
        var elementSum = 0;
        var fieldsInElement = new List<Field>();
        foreach (var field in Fields)
        {
            if (pred(i, field))
            {
                if (field.Value == 0)
                    fieldsInElement.Add(field);
                else
                    elementSum += field.Value;
            }
        }
        if (elementSum == 45)
            return false;

        foreach (var killer in _killerValues)
        {
            var inElement = true;
            foreach (var field in killer.Key)
            {
                if (!fieldsInElement.Contains(field))
                    inElement = false;
            }

            if (inElement)
            {
                elementSum += killer.Value;
                fieldsInElement.RemoveAll(x => killer.Key.Contains(x));
            }
        }
        if (elementSum == 45)
            return false;

        return KillerReducingFromSum(fieldsInElement, 45 - elementSum);
    }

    protected override void ReduceKillerFields(Field field)
    {
        var killer = _killerValues.Where(x => x.Key.Contains(field)).FirstOrDefault();

        KillerReducingFromSum(killer.Key, killer.Value);
    }

    protected override void RefreshKillerValues()
    {
        foreach (var killer in _killerValues)
        {
            var newKillerList = new List<Field>();
            foreach (var field in killer.Key)
            {
                var newField = Fields.Where(x => x.Coordinate.Equals(field.Coordinate.X, field.Coordinate.Y)).FirstOrDefault();
                if (newField == null)
                    continue;
                newKillerList.Add(newField);
            }
            killer.Key.Clear();
            killer.Key.AddRange(newKillerList);
        }
    }
}
