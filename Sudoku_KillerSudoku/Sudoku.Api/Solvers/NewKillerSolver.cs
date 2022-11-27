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
            var min = 0;
            var max = 0;
            for (int i = 1; i < killer.Key.Count; i++)
            {
                min += i;
                max += (10 - i);
            }
            for (int i = (killer.Value - min) + 1; i < 10; i++)
            {
                foreach (var field in killer.Key)
                {
                    field.RemoveValue(i);
                }
            }
            for (int i = (killer.Value - max) - 1; i > 0; i--)
            {
                foreach (var field in killer.Key)
                {
                    field.RemoveValue(i);
                }
            }
        }
    }
}
