using System;
using System.Collections.Generic;

namespace Killer_Sudoku_2
{
    class Program
    {
        private static Random random;
        private static GeneticAlgorithm<int[]> geneticAlgorithm;
        private static int[][] board;

        static void Main(string[] args)
        {
            random = new Random();
            geneticAlgorithm = new GeneticAlgorithm<int[]>(500, 4, random, getRandomGene, FitnessFunction);
            board = new int[4][];
            board[0] = new int[] { 1, 0, 0, 0 };
            board[1] = new int[] { 0, 0, 0, 2 };
            board[2] = new int[] { 0, 0, 3, 0 };
            board[3] = new int[] { 0, 4, 0, 0 };
            
            printBoard(board, 4);

            while (geneticAlgorithm.BestFitness != 0)
            {
                geneticAlgorithm.NewGeneration();
                /*Console.Write(geneticAlgorithm.Generation+", ");
                Console.Write(geneticAlgorithm.Population.Count+", ");
                Console.WriteLine();
                for (int i = 0; i < geneticAlgorithm.BestGenes.Length; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(geneticAlgorithm.BestGenes[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(geneticAlgorithm.BestFitness);*/
            }

            Console.WriteLine(geneticAlgorithm.Generation);
            printBoard(geneticAlgorithm.BestGenes, 4);
        }

        private static void printBoard(int[][] board, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[] getRandomGene()
        {
            int[] gene = new int[4];

            for (int i = 0; i < 4; i++)
            {
                gene[i] = random.Next(1, 5);
            }

            return gene;
        }

        private static double FitnessFunction(int index)
        {
            double fitness = 0;
            int[][] genes = geneticAlgorithm.Population[index].Genes;

            for (int i = 0; i < genes.Length; i++)
            {
                for (int j = 0; j < genes.Length; j++)
                {
                    if (board[i][j] != 0 && board[i][j] != genes[i][j])
                        fitness += 1000;
                }
            }

            for (int i = 0; i < genes.Length; i++)
            {
                int sum = 0;
                bool hasSameValue = false;

                for (int j = 0; j < genes.Length; j++)
                {
                    sum += genes[i][j];

                    for (int k = j-1; k >= 0; k--)
                    {
                        if (genes[i][j] == genes[i][k])
                            hasSameValue = true;
                    }
                }

                fitness += Math.Abs(10 - sum);
                if (hasSameValue)
                    fitness += 50;
            }

            for (int j = 0; j < genes.Length; j++)
            {
                int sum = 0;
                bool hasSameValue = false;

                for (int i = 0; i < genes.Length; i++)
                {
                    sum += genes[i][j];

                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (genes[k][j] == genes[i][j])
                            hasSameValue = true;
                    }
                }

                fitness += Math.Abs(10 - sum);
                if (hasSameValue)
                    fitness += 50;
            }

            int geneLength = (int)Math.Sqrt(genes.Length);

            for (int x = 0; x < genes.Length; x+= geneLength)
            {
                for (int y = 0; y < genes.Length; y+= geneLength)
                {
                    int sum = 0;
                    bool hasSameValue = false;
                    int[] values = new int[genes.Length];
                    int valueCnt = 0;

                    for (int i = x; i < x + geneLength; i++)
                    {
                        for (int j = y; j < y + geneLength; j++)
                        {
                            sum += genes[i][j];
                            values[valueCnt] = genes[i][j];

                            for (int k = valueCnt - 1; k >= 0; k--)
                            {
                                if (values[k] == values[valueCnt])
                                    hasSameValue = true;
                            }

                            valueCnt++;
                        }
                    }

                    fitness += Math.Abs(10 - sum);
                    if (hasSameValue)
                        fitness += 50;
                }
            }

            return fitness;
        }
    }
}
