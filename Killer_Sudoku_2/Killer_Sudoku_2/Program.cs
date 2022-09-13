using System;
using System.Collections.Generic;

namespace Killer_Sudoku_2
{
    class Program
    {
        private static Random random;
        private static GeneticAlgorithm geneticAlgorithm;
        private static int size;
        private static Dictionary<int, int> numberValues;
        private static int[][][] testPuzzles;
        private static int testN;
        private static Dictionary<int[][], int> killerValues;

        static void Main()
        {
            size = 9;
            random = new Random();
            testN = 2;
            InitTest(testN);

            numberValues = new Dictionary<int, int>();

            geneticAlgorithm = new GeneticAlgorithm(1000, 9, testPuzzles[testN], random, GetRandomGenes, KillerFitness);
             
            PrintBoard(testPuzzles[testN]);

            while (geneticAlgorithm.BestFitness != 0)
            {
                geneticAlgorithm.NewGeneration();
                Console.Write(geneticAlgorithm.Generation+", ");
                Console.Write(geneticAlgorithm.Population.Count+", ");
                Console.WriteLine();
                PrintBoard(geneticAlgorithm.BestGenes);
                Console.WriteLine(geneticAlgorithm.BestFitness);
                /*if(geneticAlgorithm.Generation == 500)
                    geneticAlgorithm = new GeneticAlgorithm(1000, 9, testPuzzles[testN], random, getRandomGenes, FitnessFunction);*/
            }

            Console.WriteLine(geneticAlgorithm.Generation);
            PrintBoard(geneticAlgorithm.BestGenes);
        }

        private static void PrintBoard(int[][] board)
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

        private static void GetRandomGenes(int[][] genes)
        {
            for (int i = 0; i < genes.Length; i++)
            {
                for (int j = 0; j < genes.Length; j++)
                {
                    genes[i][j] = testPuzzles[testN][i][j];
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

        private static int FitnessFunction(int index)
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
        private static int CalculatePenalty()
        {
            int penalty = 0;

            foreach(var numbers in numberValues)
            {
                if (numbers.Value == 0)
                    penalty++;
                else
                    penalty += Math.Abs(numbers.Value - 1);
            }

            return penalty;
        }

        private static void ResetDictionary()
        {
            for (int i = 0; i < size; i++)
            {
                numberValues[i + 1] = 0;
            }
        }

        private static void InitTest(int test)
        {
            testPuzzles = new int[7][][];

            for (int i = 0; i < 7; i++)
            {
                testPuzzles[i] = new int[size][];
            }
            killerValues = new Dictionary<int[][], int>();
            switch (test)
            {
                case 0:
                    {
                        //EASY
                        testPuzzles[0][0] = new int[] { 3, 0, 0, 4, 0, 9, 0, 0, 7 };
                        testPuzzles[0][1] = new int[] { 6, 0, 0, 8, 0, 1, 0, 4, 9 };
                        testPuzzles[0][2] = new int[] { 0, 0, 4, 0, 0, 7, 6, 0, 0 };
                        testPuzzles[0][3] = new int[] { 9, 4, 6, 0, 2, 0, 0, 7, 0 };
                        testPuzzles[0][4] = new int[] { 1, 5, 7, 3, 0, 0, 2, 8, 0 };
                        testPuzzles[0][5] = new int[] { 8, 0, 2, 7, 4, 5, 0, 0, 0 };
                        testPuzzles[0][6] = new int[] { 0, 0, 0, 8, 0, 5, 7, 3, 4 };
                        testPuzzles[0][7] = new int[] { 4, 0, 0, 0, 6, 0, 0, 0, 8 };
                        testPuzzles[0][8] = new int[] { 0, 0, 0, 0, 2, 0, 5, 0, 0 };
                    }break;
                case 1:
                    {
                        //MEDIUM
                        testPuzzles[1][0] = new int[] { 0, 6, 9, 3, 0, 0, 0, 8, 0 };
                        testPuzzles[1][1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0 };
                        testPuzzles[1][2] = new int[] { 0, 0, 0, 6, 7, 0, 0, 0, 0 };
                        testPuzzles[1][3] = new int[] { 1, 2, 0, 0, 0, 0, 0, 7, 0 };
                        testPuzzles[1][4] = new int[] { 7, 0, 5, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[1][5] = new int[] { 3, 9, 6, 0, 0, 0, 2, 8, 0 };
                        testPuzzles[1][6] = new int[] { 0, 0, 2, 7, 3, 0, 8, 1, 0 };
                        testPuzzles[1][7] = new int[] { 3, 0, 0, 5, 0, 0, 0, 2, 9 };
                        testPuzzles[1][8] = new int[] { 4, 1, 0, 9, 0, 8, 0, 0, 0 };
                    } break;
                case 2:
                    {
                        //HARD
                        testPuzzles[2][0] = new int[] { 0, 0, 1, 0, 0, 0, 4, 0, 6 };
                        testPuzzles[2][1] = new int[] { 0, 0, 5, 0, 0, 9, 3, 0, 0 };
                        testPuzzles[2][2] = new int[] { 0, 0, 4, 0, 0, 6, 0, 0, 8 };
                        testPuzzles[2][3] = new int[] { 0, 0, 0, 0, 0, 7, 0, 0, 4 };
                        testPuzzles[2][4] = new int[] { 0, 0, 0, 0, 8, 0, 0, 0, 3 };
                        testPuzzles[2][5] = new int[] { 0, 0, 0, 0, 0, 1, 5, 0, 0 };
                        testPuzzles[2][6] = new int[] { 0, 0, 3, 0, 7, 0, 9, 6, 0 };
                        testPuzzles[2][7] = new int[] { 0, 0, 7, 9, 0, 0, 0, 0, 0 };
                        testPuzzles[2][8] = new int[] { 2, 0, 0, 1, 0, 0, 0, 0, 0 };
                    } break;
                case 3:
                    {
                        //easy killer
                        testPuzzles[3][0] = new int[] { 0, 5, 0, 0, 0, 3, 6, 0, 0 };
                        testPuzzles[3][1] = new int[] { 0, 0, 0, 0, 8, 0, 0, 5, 4 };
                        testPuzzles[3][2] = new int[] { 0, 4, 0, 2, 5, 9, 8, 7, 0 };
                        testPuzzles[3][3] = new int[] { 0, 0, 0, 0, 3, 0, 0, 0, 0 };
                        testPuzzles[3][4] = new int[] { 0, 7, 2, 4, 1, 5, 0, 0, 8 };
                        testPuzzles[3][5] = new int[] { 0, 0, 0, 0, 2, 0, 4, 0, 0 };
                        testPuzzles[3][6] = new int[] { 0, 8, 4, 0, 0, 0, 0, 1, 5 };
                        testPuzzles[3][7] = new int[] { 9, 6, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[3][8] = new int[] { 0, 3, 7, 0, 0, 2, 0, 0, 0 };
                        killerValues.Add(new int[5][] { new int[2] { 0, 0 }, new int[2] { 0, 1 }, 
                            new int[2] { 0, 2 }, new int[2] { 0, 3 }, new int[2] { 0, 5 } }, 22);
                        killerValues.Add(new int[5][] { new int[2] { 0, 4 }, new int[2] { 0, 7 }, 
                            new int[2] { 0, 8 }, new int[2] { 1, 6 }, new int[2] { 3, 2 } }, 27);
                        killerValues.Add(new int[2][] { new int[2] { 0, 6 }, new int[2] { 3, 0 } }, 7);
                        killerValues.Add(new int[2][] { new int[2] { 1, 0 }, new int[2] { 1, 1 } }, 10);
                        killerValues.Add(new int[2][] { new int[2] { 1, 3 }, new int[2] { 1, 4 } }, 9);
                        killerValues.Add(new int[3][] { new int[2] { 1, 2 }, new int[2] { 2, 0 }, 
                            new int[2] { 2, 3 } }, 17);
                        killerValues.Add(new int[4][] { new int[2] { 1, 5 }, new int[2] { 1, 7 }, 
                            new int[2] { 1, 8 }, new int[2] { 4, 2 } }, 17);
                        killerValues.Add(new int[4][] { new int[2] { 2, 1 }, new int[2] { 2, 2 }, 
                            new int[2] { 2, 4 }, new int[2] { 2, 5 } }, 19);
                        killerValues.Add(new int[2][] { new int[2] { 2, 7 }, new int[2] { 2, 8 } }, 10);
                        killerValues.Add(new int[5][] { new int[2] { 2, 6 }, new int[2] { 5, 0 }, 
                            new int[2] { 5, 1 }, new int[2] { 5, 3 }, new int[2] { 5, 4 } }, 29);
                        killerValues.Add(new int[5][] { new int[2] { 3, 1 }, new int[2] { 3, 3 }, 
                            new int[2] { 3, 4 }, new int[2] { 3, 6 }, new int[2] { 3, 7 } }, 23);
                        killerValues.Add(new int[6][] { new int[2] { 3, 5 }, new int[2] { 3, 8 }, 
                            new int[2] { 4, 3 }, new int[2] { 4, 4 }, new int[2] { 4, 6 }, 
                            new int[2] { 4, 7 } }, 30);
                        killerValues.Add(new int[2][] { new int[2] { 4, 0 }, new int[2] { 4, 1 } }, 13);
                        killerValues.Add(new int[4][] { new int[2] { 4, 5 }, new int[2] { 4, 8 }, 
                            new int[2] { 5, 6 }, new int[2] { 7, 2 } }, 18);
                        killerValues.Add(new int[2][] { new int[2] { 5, 2 }, new int[2] { 5, 5 } }, 13);
                        killerValues.Add(new int[2][] { new int[2] { 5, 7 }, new int[2] { 5, 8 } }, 7);
                        killerValues.Add(new int[3][] { new int[2] { 6, 0 }, new int[2] { 6, 3 }, 
                            new int[2] { 6, 4 } }, 11);
                        killerValues.Add(new int[3][] { new int[2] { 6, 1 }, new int[2] { 6, 2 }, 
                            new int[2] { 6, 5 } }, 21);
                        killerValues.Add(new int[2][] { new int[2] { 6, 6 }, new int[2] { 6, 7 } }, 8);
                        killerValues.Add(new int[3][] { new int[2] { 6, 8 }, new int[2] { 7, 6 }, 
                            new int[2] { 7, 7 } }, 15);
                        killerValues.Add(new int[2][] { new int[2] { 7, 0 }, new int[2] { 7, 3 } }, 14);
                        killerValues.Add(new int[3][] { new int[2] { 7, 1 }, new int[2] { 7, 4 }, 
                            new int[2] { 7, 5 } }, 17);
                        killerValues.Add(new int[4][] { new int[2] { 7, 8 }, new int[2] { 8, 3 }, 
                            new int[2] { 8, 6 }, new int[2] { 8, 7 } }, 19);
                        killerValues.Add(new int[6][] { new int[2] { 8, 0 }, new int[2] { 8, 1 }, 
                            new int[2] { 8, 2 }, new int[2] { 8, 4 }, new int[2] { 8, 5 }, 
                            new int[2] { 8, 8 } }, 29);
                    } break;
                case 4:
                    {
                        //medium killer
                        testPuzzles[4][0] = new int[] { 0, 0, 1, 0, 0, 0, 7, 0, 0 };
                        testPuzzles[4][1] = new int[] { 5, 0, 9, 3, 0, 0, 0, 0, 0 };
                        testPuzzles[4][2] = new int[] { 2, 3, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[4][3] = new int[] { 2, 5, 0, 0, 0, 0, 0, 6, 0 };
                        testPuzzles[4][4] = new int[] { 0, 0, 0, 0, 0, 5, 0, 9, 2 };
                        testPuzzles[4][5] = new int[] { 7, 0, 0, 0, 0, 2, 0, 0, 0 };
                        testPuzzles[4][6] = new int[] { 0, 0, 0, 0, 0, 8, 5, 0, 0 };
                        testPuzzles[4][7] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[4][8] = new int[] { 4, 0, 0, 0, 7, 1, 0, 0, 0 };
                        killerValues.Add(new int[2][] { new int[2] { 0, 0 }, new int[2] { 0, 3 } }, 15);
                        killerValues.Add(new int[3][] { new int[2] { 0, 1 }, new int[2] { 0, 2 }, 
                            new int[2] { 0, 4 } }, 11);
                        killerValues.Add(new int[3][] { new int[2] { 0, 6 }, new int[2] { 3, 0 },
                            new int[2] { 3, 3 } }, 17);
                        killerValues.Add(new int[4][] { new int[2] { 0, 7 }, new int[2] { 3, 1 },
                            new int[2] { 3, 4 }, new int[2] { 3, 5 } }, 16);
                        killerValues.Add(new int[3][] { new int[2] { 0, 5 }, new int[2] { 0, 8 },
                            new int[2] { 1, 6 } }, 11);
                        killerValues.Add(new int[4][] { new int[2] { 1, 0 }, new int[2] { 1, 1 },
                            new int[2] { 1, 3 }, new int[2] { 1, 4 } }, 23);
                        killerValues.Add(new int[3][] { new int[2] { 1, 2 }, new int[2] { 1, 5 },
                            new int[2] { 1, 8 } }, 14);
                        killerValues.Add(new int[3][] { new int[2] { 1, 7 }, new int[2] { 4, 1 },
                            new int[2] { 4, 4 } }, 13);
                        killerValues.Add(new int[3][] { new int[2] { 2, 0 }, new int[2] { 2, 3 },
                            new int[2] { 2, 6 } }, 16);
                        killerValues.Add(new int[2][] { new int[2] { 2, 1 }, new int[2] { 2, 4 } }, 4);
                        killerValues.Add(new int[4][] { new int[2] { 2, 2 }, new int[2] { 2, 5 },
                            new int[2] { 2, 7 }, new int[2] { 2, 8 } }, 25);
                        killerValues.Add(new int[2][] { new int[2] { 3, 6 }, new int[2] { 3, 7 } }, 10);
                        killerValues.Add(new int[2][] { new int[2] { 3, 2 }, new int[2] { 4, 0 } }, 10);
                        killerValues.Add(new int[5][] { new int[2] { 3, 8 }, new int[2] { 4, 3 },
                            new int[2] { 4, 6 }, new int[2] { 7, 0 }, new int[2] { 7, 3 } }, 33);
                        killerValues.Add(new int[2][] { new int[2] { 4, 2 }, new int[2] { 5, 0 } }, 15);
                        killerValues.Add(new int[5][] { new int[2] { 4, 5 }, new int[2] { 5, 3 },
                            new int[2] { 5, 4 }, new int[2] { 5, 5 }, new int[2] { 5, 8 } }, 28);
                        killerValues.Add(new int[3][] { new int[2] { 4, 8 }, new int[2] { 5, 6 },
                            new int[2] { 5, 7 } }, 8);
                        killerValues.Add(new int[2][] { new int[2] { 5, 1 }, new int[2] { 5, 2 } }, 9);
                        killerValues.Add(new int[2][] { new int[2] { 6, 0 }, new int[2] { 6, 1 } }, 8);
                        killerValues.Add(new int[2][] { new int[2] { 6, 2 }, new int[2] { 6, 5 } }, 14);
                        killerValues.Add(new int[2][] { new int[2] { 6, 3 }, new int[2] { 6, 6 } }, 8);
                        killerValues.Add(new int[3][] { new int[2] { 6, 4 }, new int[2] { 6, 7 },
                            new int[2] { 6, 8 } }, 15);
                        killerValues.Add(new int[2][] { new int[2] { 7, 6 }, new int[2] { 7, 7 } }, 5);
                        killerValues.Add(new int[2][] { new int[2] { 7, 5 }, new int[2] { 7, 8 } }, 13);
                        killerValues.Add(new int[4][] { new int[2] { 7, 2 }, new int[2] { 8, 0 },
                            new int[2] { 8, 3 }, new int[2] { 8, 4 } }, 19);
                        killerValues.Add(new int[2][] { new int[2] { 8, 1 }, new int[2] { 8, 2 } }, 11);
                        killerValues.Add(new int[2][] { new int[2] { 8, 6 }, new int[2] { 8, 7 } }, 11);
                        killerValues.Add(new int[2][] { new int[2] { 8, 5 }, new int[2] { 8, 8 } }, 7);
                    }
                    break;
                case 5:
                    {
                        //hard killer
                        testPuzzles[5][0] = new int[] { 0, 0, 0, 2, 0, 0, 0, 7, 0 };
                        testPuzzles[5][1] = new int[] { 0, 7, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[5][2] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[5][3] = new int[] { 0, 0, 0, 0, 5, 8, 0, 0, 0 };
                        testPuzzles[5][4] = new int[] { 0, 0, 5, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[5][5] = new int[] { 0, 0, 8, 0, 0, 9, 0, 0, 5 };
                        testPuzzles[5][6] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[5][7] = new int[] { 5, 6, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[5][8] = new int[] { 0, 0, 7, 0, 5, 1, 0, 3, 0 };
                        killerValues.Add(new int[4][] { new int[2] { 0, 0 }, new int[2] { 0, 3 },
                            new int[2] { 0, 6 }, new int[2] { 0, 7 } }, 20);
                        killerValues.Add(new int[2][] { new int[2] { 0, 1 }, new int[2] { 0, 4 } }, 9);
                        killerValues.Add(new int[2][] { new int[2] { 0, 2 }, new int[2] { 0, 5 } }, 13);
                        killerValues.Add(new int[3][] { new int[2] { 0, 8 }, new int[2] { 3, 2 },
                            new int[2] { 4, 0 } }, 12);
                        killerValues.Add(new int[5][] { new int[2] { 1, 0 }, new int[2] { 1, 3 },
                            new int[2] { 1, 4 }, new int[2] { 1, 6 }, new int[2] { 1, 7 } }, 24);
                        killerValues.Add(new int[2][] { new int[2] { 1, 1 }, new int[2] { 1, 2 } }, 9);
                        killerValues.Add(new int[4][] { new int[2] { 1, 5 }, new int[2] { 1, 8 },
                            new int[2] { 4, 1 }, new int[2] { 4, 2 } }, 26);
                        killerValues.Add(new int[3][] { new int[2] { 2, 0 }, new int[2] { 2, 3 },
                            new int[2] { 2, 4 } }, 14);
                        killerValues.Add(new int[2][] { new int[2] { 2, 1 }, new int[2] { 2, 2 } }, 12);
                        killerValues.Add(new int[2][] { new int[2] { 2, 5 }, new int[2] { 2, 8 } }, 6);
                        killerValues.Add(new int[3][] { new int[2] { 2, 6 }, new int[2] { 5, 0 },
                            new int[2] { 5, 3 } }, 14);
                        killerValues.Add(new int[2][] { new int[2] { 2, 7 }, new int[2] { 5, 1 } }, 9);
                        killerValues.Add(new int[2][] { new int[2] { 3, 0 }, new int[2] { 3, 3 } }, 7);
                        killerValues.Add(new int[3][] { new int[2] { 3, 1 }, new int[2] { 3, 4 },
                            new int[2] { 3, 5 } }, 19);
                        killerValues.Add(new int[2][] { new int[2] { 3, 7 }, new int[2] { 3, 8 } }, 16);
                        killerValues.Add(new int[4][] { new int[2] { 3, 6 }, new int[2] { 6, 0 },
                            new int[2] { 6, 3 }, new int[2] { 6, 4 } }, 18);
                        killerValues.Add(new int[5][] { new int[2] { 4, 3 }, new int[2] { 4, 4 },
                            new int[2] { 4, 6 }, new int[2] { 4, 7 }, new int[2] { 7, 1 } }, 23);
                        killerValues.Add(new int[4][] { new int[2] { 4, 5 }, new int[2] { 4, 8 },
                            new int[2] { 5, 6 }, new int[2] { 8, 0 } }, 13);
                        killerValues.Add(new int[2][] { new int[2] { 5, 4 }, new int[2] { 5, 7 } }, 9);
                        killerValues.Add(new int[4][] { new int[2] { 5, 2 }, new int[2] { 5, 5 },
                            new int[2] { 5, 8 }, new int[2] { 8, 2 } }, 29);
                        killerValues.Add(new int[2][] { new int[2] { 6, 6 }, new int[2] { 6, 7 } }, 13);
                        killerValues.Add(new int[5][] { new int[2] { 6, 1 }, new int[2] { 6, 2 },
                            new int[2] { 6, 5 }, new int[2] { 7, 0 }, new int[2] { 7, 3 } }, 19);
                        killerValues.Add(new int[2][] { new int[2] { 6, 8 }, new int[2] { 7, 6 } }, 6);
                        killerValues.Add(new int[5][] { new int[2] { 7, 2 }, new int[2] { 7, 4 },
                            new int[2] { 7, 5 }, new int[2] { 7, 7 }, new int[2] { 7, 8 } }, 29);
                        killerValues.Add(new int[3][] { new int[2] { 8, 1 }, new int[2] { 8, 4 },
                            new int[2] { 8, 5 } }, 10);
                        killerValues.Add(new int[2][] { new int[2] { 8, 3 }, new int[2] { 8, 6 } }, 17);
                        killerValues.Add(new int[2][] { new int[2] { 8, 7 }, new int[2] { 8, 8 } }, 9);
                    }
                    break;
                case 6:
                    {
                        //killer killer
                        testPuzzles[6][0] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][2] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][3] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][4] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][5] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][6] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][7] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        testPuzzles[6][8] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        killerValues.Add(new int[2][] { new int[2] { 0, 0 }, new int[2] { 0, 1 } }, 6);
                        killerValues.Add(new int[2][] { new int[2] { 0, 2 }, new int[2] { 1, 0 } }, 12);
                        killerValues.Add(new int[5][] { new int[2] { 0, 3 }, new int[2] { 0, 4 },
                            new int[2] { 0, 5 }, new int[2] { 0, 7 }, new int[2] { 1, 3 } }, 28);
                        killerValues.Add(new int[2][] { new int[2] { 0, 6 }, new int[2] { 3, 0 } }, 11);
                        killerValues.Add(new int[2][] { new int[2] { 0, 8 }, new int[2] { 3, 2 } }, 13);
                        killerValues.Add(new int[4][] { new int[2] { 1, 4 }, new int[2] { 1, 6 },
                            new int[2] { 1, 7 }, new int[2] { 1, 8 } }, 11);
                        killerValues.Add(new int[4][] { new int[2] { 1, 1 }, new int[2] { 1, 2 },
                            new int[2] { 1, 5 }, new int[2] { 2, 0 } }, 26);
                        killerValues.Add(new int[4][] { new int[2] { 2, 1 }, new int[2] { 2, 2 },
                            new int[2] { 2, 5 }, new int[2] { 2, 8 } }, 21);
                        killerValues.Add(new int[2][] { new int[2] { 2, 3 }, new int[2] { 2, 6 } }, 12);
                        killerValues.Add(new int[2][] { new int[2] { 2, 4 }, new int[2] { 2, 7 } }, 10);
                        killerValues.Add(new int[3][] { new int[2] { 3, 1 }, new int[2] { 3, 4 },
                            new int[2] { 3, 7 } }, 10);
                        killerValues.Add(new int[2][] { new int[2] { 3, 3 }, new int[2] { 3, 6 } }, 11);
                        killerValues.Add(new int[3][] { new int[2] { 3, 5 }, new int[2] { 4, 0 },
                            new int[2] { 4, 3 } }, 18);
                        killerValues.Add(new int[4][] { new int[2] { 3, 8 }, new int[2] { 4, 6 },
                            new int[2] { 7, 0 }, new int[2] { 7, 1 } }, 25);
                        killerValues.Add(new int[3][] { new int[2] { 4, 1 }, new int[2] { 4, 2 },
                            new int[2] { 4, 5 } }, 7);
                        killerValues.Add(new int[2][] { new int[2] { 4, 4 }, new int[2] { 4, 7 } }, 14);
                        killerValues.Add(new int[2][] { new int[2] { 4, 8 }, new int[2] { 5, 6 } }, 13);
                        killerValues.Add(new int[2][] { new int[2] { 5, 0 }, new int[2] { 5, 3 } }, 6);
                        killerValues.Add(new int[3][] { new int[2] { 5, 1 }, new int[2] { 5, 2 },
                            new int[2] { 5, 4 } }, 12);
                        killerValues.Add(new int[2][] { new int[2] { 5, 7 }, new int[2] { 8, 1 } }, 9);
                        killerValues.Add(new int[3][] { new int[2] { 5, 5 }, new int[2] { 5, 8 },
                            new int[2] { 8, 2 } }, 23);
                        killerValues.Add(new int[3][] { new int[2] { 6, 0 }, new int[2] { 6, 1 },
                            new int[2] { 6, 4 } }, 14);
                        killerValues.Add(new int[2][] { new int[2] { 6, 3 }, new int[2] { 6, 6 } }, 11);
                        killerValues.Add(new int[4][] { new int[2] { 6, 2 }, new int[2] { 6, 5 },
                            new int[2] { 6, 7 }, new int[2] { 6, 8 } }, 20);
                        killerValues.Add(new int[2][] { new int[2] { 7, 2 }, new int[2] { 7, 5 } }, 9);
                        killerValues.Add(new int[3][] { new int[2] { 7, 3 }, new int[2] { 7, 4 },
                            new int[2] { 7, 6 } }, 10);
                        killerValues.Add(new int[2][] { new int[2] { 7, 7 }, new int[2] { 7, 8 } }, 9);
                        killerValues.Add(new int[2][] { new int[2] { 8, 0 }, new int[2] { 8, 3 } }, 10);
                        killerValues.Add(new int[3][] { new int[2] { 8, 4 }, new int[2] { 8, 5 },
                            new int[2] { 8, 8 } }, 7);
                        killerValues.Add(new int[2][] { new int[2] { 8, 6 }, new int[2] { 8, 7 } }, 17);
                    }
                    break;
            }           
        }

        private static int KillerFitness(int index)
        {
            int fitness = 0;
            fitness += FitnessFunction(index);
            int[][] genes = geneticAlgorithm.Population[index].Genes;
            foreach(var kv in killerValues)
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
    }
}
