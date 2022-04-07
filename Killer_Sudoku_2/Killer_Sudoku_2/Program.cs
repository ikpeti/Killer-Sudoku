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
            geneticAlgorithm = new GeneticAlgorithm(21, 4, board, random, getRandomGenes, FitnessFunction);
             
            printBoard(board);

            numberValues = new Dictionary<int, int>();
            for (int i = 0; i < size; i++)
            {
                numberValues.Add(i + 1, 0);
            }
            
            while (geneticAlgorithm.BestFitness != 0)
            {
                geneticAlgorithm.NewGeneration();
                Console.Write(geneticAlgorithm.Generation+", ");
                Console.Write(geneticAlgorithm.Population.Count+", ");
                Console.WriteLine();
                for (int i = 0; i < geneticAlgorithm.BestGenes.Length; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(geneticAlgorithm.BestGenes[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(geneticAlgorithm.BestFitness);
            }

            Console.WriteLine(geneticAlgorithm.Generation);
            printBoard(geneticAlgorithm.BestGenes);
        }

        //TODO
        private static void printBoard(int[][] board)
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

        private static void getRandomGenes(int[][] genes)
        {
            for (int i = 0; i < genes.Length; i++)
            {
                for (int j = 0; j < genes.Length; j++)
                {
                    if (board[i][j] != 0)
                        genes[i][j] = board[i][j];
                    else
                    {
                        //TODO
                        genes[i][j] = random.Next(1, size + 1);
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

            int x = 0;
            for (int i = 0; i < genes.Length; i += geneLength)
            {
                int y = 0;

                for (int l = 0; l < geneLength; l++)
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

                    y += 2;
                }

                x += 2;
            }

            //TODO
            /*
            x = 0;
            for (int i = 0; i < genes.Length; i += geneLength)
            {
                int y = 0;

                for (int j = x; j < x + geneLength; j++)
                {
                    for (int k = y; k < y + geneLength; k++)
                    {
                        numberValues[genes[j][k]]++;
                    }
                    y += 2;
                }

                fitness += calculatePenalty();

                x += 2;
            }
            */
            return fitness;
        }

        //TODO
        private static double calculatePenalty()
        {
            double penalty = 0;



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
