namespace Sudoku.Api.Types;
public class Field
{
    public Coordinate Coordinate { get; }
    public int Value { get; private set; }
    public List<int> PossibleValues { get; }
    public Field(int x, int y, int value = 0)
    {
        Coordinate = new()
        {
            X = x,
            Y = y
        };
        Value = value;
        PossibleValues = new List<int>();
        if (value == 0)
        {
            PossibleValues.AddRange(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }
    }

    public bool RemoveValue(int value)
    {
        if (PossibleValues.Contains(value))
        {
            PossibleValues.Remove(value);
            return true;
        }
        return false;
    }

    public void KeepValue(int value)
    {
        if (PossibleValues.Contains(value))
            PossibleValues.RemoveAll(x => x != value);
    }

    public void SetValue()
    {
        if (PossibleValues.Count != 1)
            return;
        Value = PossibleValues[0];
        PossibleValues.RemoveAt(0);
    }

    public void SetValues(int value, List<int> possibleValues)
    {
        Value = value;
        PossibleValues.RemoveAll(x => !possibleValues.Contains(x));
    }
}
