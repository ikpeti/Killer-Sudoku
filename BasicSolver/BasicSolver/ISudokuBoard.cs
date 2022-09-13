using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSolver;
public interface ISudokuBoard
{
    public int Size { get; }
    public int[,] Board { get; }
    public void Init(int[,] board);
    public void Print();
    public bool Solve();
}
