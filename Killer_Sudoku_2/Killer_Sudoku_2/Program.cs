using System;
using System.Collections.Generic;

namespace Killer_Sudoku_2
{
    class Program
    {
        private static Random random;
        private static GeneticAlgorithm geneticAlgorithm;
        private static int[][] board;
        private static int size;
        private static Dictionary<int, int> numberValues;

        static void Main()
        {
            size = 4;
            random = new Random();
            board = new int[size][];
            board[0] = new int[] { 1, 0, 0, 0 };
            board[1] = new int[] { 0, 0, 0, 2 };
            board[2] = new int[] { 0, 0, 0, 4 };
            board[3] = new int[] { 3, 0, 0, 0 };

            numberValues = new Dictionary<int, int>();
            for (int i = 0; i < size; i++)
            {
                numberValues.Add(i + 1, 0);
            }

            geneticAlgorithm = new GeneticAlgorithm(21, 4, board, random, getRandomGenes, FitnessFunction);
             
            printBoard(board);

            while (geneticAlgorithm.BestFitness != 0)
            {
                geneticAlgorithm.NewGeneration();
                Console.Write(geneticAlgorithm.Generation+", ");
                Console.Write(geneticAlgorithm.Population.Count+", ");
                Console.WriteLine();
                printBoard(geneticAlgorithm.BestGenes);
                Console.WriteLine(geneticAlgorithm.BestFitness);
            }

            Console.WriteLine(geneticAlgorithm.Generation);
            printBoard(geneticAlgorithm.BestGenes);
        }

        //TODO
        private static void printBoard(int[][] board)
        {
            for (int x = 0; x < board.Length; x += (int)Math.Sqrt(size))
            {
                for (int y = 0; y < board.Length; y += (int)Math.Sqrt(size))
                {
                    for (int j = x; j < x + (int)Math.Sqrt(size); j++)
                    {
                        for (int k = y; k < y + (int)Math.Sqrt(size); k++)
                        {
                            Console.Write(board[j][k]);
                        }
                    }
                    Console.WriteLine("");
                }
            }
        }

        private static void getRandomGenes(int[][] genes)
        {
            for (int i = 0; i < genes.Length; i++)
            {
                for (int j = 0; j < genes.Length; j++)
                {
                    genes[i][j] = board[i][j];
                }
            }
            for (int i = 0; i < genes.Length; i++)
            {
                for (int j = 0; j < genes.Length; j++)
                {
                    if (board[i][j] == 0)
                    {
                        resetDictionary();
                        for (int y = 0; y < genes.Length; y++)
                        {
                            if(genes[i][y] != 0)
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

        private static double FitnessFunction(int index)
        {
            double fitness = 0;
            int[][] genes = geneticAlgorithm.Population[index].Genes;
            int geneLength = (int)Math.Sqrt(genes.Length);
            resetDictionary();

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
                    fitness += calculatePenalty();
                    resetDictionary();
                }
            }

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
                    fitness += calculatePenalty();
                    resetDictionary();
                }
            }
            return fitness;
        }
        private static double calculatePenalty()
        {
            double penalty = 0;

            foreach(var numbers in numberValues)
            {
                if (numbers.Value == 0)
                    penalty++;
                else
                    penalty += Math.Abs(numbers.Value - 1);
            }

            return penalty;
        }

        private static void resetDictionary()
        {
            for (int i = 0; i < size; i++)
            {
                numberValues[i + 1] = 0;
            }
        }
    }
}
