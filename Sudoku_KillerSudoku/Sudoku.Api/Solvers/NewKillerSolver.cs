using Sudoku.Api.Types;

namespace Sudoku.Api.Solvers;
public class NewKillerSolver : NewSolver
{
    private Dictionary<List<Field>, int> _killerValues;
    public NewKillerSolver(int size, List<List<int>> killerFields, List<int> killerValues, int[,]? sudoku = null) : base(size, sudoku)
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

    protected override bool OtherRules()
    {
        return CheckSums();
    }

    private bool KillerReducingFromSum(List<Field> fields, int value)
    {
        var result = false;
        var min = 0;
        var max = 0;
        for (int i = 1; i < fields.Count; i++)
        {
            min += i;
            max += (10 - i);
        }
        for (int i = (value - min) + 1; i < 10; i++)
        {
            foreach (var field in fields)
            {
                if (field.RemoveValue(i))
                    result = true;
            }
        }
        for (int i = (value - max) - 1; i > 0; i--)
        {
            foreach (var field in fields)
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

    protected override void RefreshKillerValues(Field field)
    {
        foreach (var killer in _killerValues)
        {
            if (killer.Key.Contains(field))
            {
                killer.Key.Remove(field);
                if (killer.Key.Count == 0)
                    _killerValues.Remove(killer.Key);
                else
                {
                    foreach (var key in killer.Key)
                        key.PossibleValues.Remove(field.Value);
                    var newKillerValue = killer.Value - field.Value;
                    _killerValues[killer.Key] = newKillerValue;
                    KillerReducingFromSum(killer.Key, newKillerValue);
                }
            }
        }
    }
}
