using Sudoku.Api.Tests;

namespace Sudoku.Api.Genetic;
public class GeneticAlgorithmRunner
{
    private Random random;
    private GeneticAlgorithm geneticAlgorithm;
    private int size;
    private Dictionary<int, int> numberValues;
    private Dictionary<int[][], int>? killerValues;
    public GeneticAlgorithmRunner(GeneticModel geneticTest)
    {
        random = new Random();
        size = 9;
        numberValues = new Dictionary<int, int>();
        SudokuConstants.SudokuProblem = geneticTest.Puzzle;
        if (geneticTest.KillerValue == null)
            geneticAlgorithm = new GeneticAlgorithm(1000, 9, GetRandomGenes, FitnessFunction);
        else
            geneticAlgorithm = new GeneticAlgorithm(1000, 9, GetRandomGenes, KillerFitness);
        killerValues = geneticTest.KillerValue;
    }
    public int[][] RunGeneticAlgorithm()
    {
        while (geneticAlgorithm.BestFitness != 0)
        {
            geneticAlgorithm.NewGeneration();
        }

        Console.WriteLine(geneticAlgorithm.Generation);
        PrintBoard(geneticAlgorithm.BestGenes);
        return geneticAlgorithm.BestGenes;
    }
    private void GetRandomGenes(int[][] genes)
    {
        for (int i = 0; i < genes.Length; i++)
        {
            for (int j = 0; j < genes.Length; j++)
            {
                genes[i][j] = SudokuConstants.SudokuProblem[i][j];
            }
        }
        for (int i = 0; i < genes.Length; i++)
        {
            for (int j = 0; j < genes.Length; j++)
            {
                if (genes[i][j] == 0)
                {
                    ResetDictionary();
                    for (int y = 0; y < genes.Length; y++)
                    {
                        if (genes[i][y] != 0)
                            numberValues[genes[i][y]]++;
                    }
                    int x = random.Next(1, size + 1);
                    while (numberValues[x] != 0)
                        x = random.Next(1, size + 1);
                    genes[i][j] = x;
                }
            }
        }
    }

    private int FitnessFunction(int index)
    {
        int fitness = 0;
        int[][] genes = geneticAlgorithm.Population[index].Genes;
        int geneLength = (int)Math.Sqrt(genes.Length);
        ResetDictionary();

        int rowPen = 0;
        for (int x = 0; x < genes.Length; x += geneLength)
        {
            for (int y = 0; y < genes.Length; y += geneLength)
            {
                for (int j = x; j < x + geneLength; j++)
                {
                    for (int k = y; k < y + geneLength; k++)
                    {
                        numberValues[genes[j][k]]++;
                    }
                }
                rowPen += CalculatePenalty();
                ResetDictionary();
            }
        }

        int columnPen = 0;
        for (int x = 0; x < geneLength; x++)
        {
            for (int y = 0; y < geneLength; y++)
            {
                for (int j = x; j < x + genes.Length; j += geneLength)
                {
                    for (int k = y; k < y + genes.Length; k += geneLength)
                    {
                        numberValues[genes[j][k]]++;
                    }
                }
                columnPen += CalculatePenalty();
                ResetDictionary();
            }
        }
        /*if ((columnPen == 0 && rowPen != 0) || (columnPen != 0 && rowPen == 0))
            fitness += 10;*/
        fitness += rowPen;
        fitness += columnPen;
        return fitness;
    }
    private int CalculatePenalty()
    {
        int penalty = 0;

        foreach (var numbers in numberValues)
        {
            if (numbers.Value == 0)
                penalty++;
            else
                penalty += Math.Abs(numbers.Value - 1);
        }

        return penalty;
    }

    private void ResetDictionary()
    {
        for (int i = 0; i < size; i++)
        {
            numberValues[i + 1] = 0;
        }
    }

    private int KillerFitness(int index)
    {
        int fitness = 0;
        fitness += FitnessFunction(index);
        int[][] genes = geneticAlgorithm.Population[index].Genes;
        foreach (var kv in killerValues!)
        {
            int sum = 0;
            for (int i = 0; i < kv.Key.Length; i++)
            {
                sum += genes[kv.Key[i][0]][kv.Key[i][1]];
            }
            fitness += Math.Abs(kv.Value - sum);
        }

        return fitness;
    }

    private void PrintBoard(int[][] board)
    {
        for (int x = 0; x < board.Length; x += (int)Math.Sqrt(size))
        {
            for (int y = 0; y < board.Length; y += (int)Math.Sqrt(size))
            {
                for (int j = x; j < x + (int)Math.Sqrt(size); j++)
                {
                    for (int k = y; k < y + (int)Math.Sqrt(size); k++)
                    {
                        Console.Write(board[j][k] + " ");
                    }
                    Console.Write("| ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("---------------------");
        }
    }
}
