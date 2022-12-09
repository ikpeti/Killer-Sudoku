namespace Sudoku.Api.Tests;
public static class GeneticTests
{
    public static GeneticModel Easy
    {
        get
        {
            var geneticModel = new GeneticModel();
            var testPuzzle = new int[9][];
            testPuzzle[0] = new int[] { 3, 0, 0, 4, 0, 9, 0, 0, 7 };
            testPuzzle[1] = new int[] { 6, 0, 0, 8, 0, 1, 0, 4, 9 };
            testPuzzle[2] = new int[] { 0, 0, 4, 0, 0, 7, 6, 0, 0 };
            testPuzzle[3] = new int[] { 9, 4, 6, 0, 2, 0, 0, 7, 0 };
            testPuzzle[4] = new int[] { 1, 5, 7, 3, 0, 0, 2, 8, 0 };
            testPuzzle[5] = new int[] { 8, 0, 2, 7, 4, 5, 0, 0, 0 };
            testPuzzle[6] = new int[] { 0, 0, 0, 8, 0, 5, 7, 3, 4 };
            testPuzzle[7] = new int[] { 4, 0, 0, 0, 6, 0, 0, 0, 8 };
            testPuzzle[8] = new int[] { 0, 0, 0, 0, 2, 0, 5, 0, 0 };
            geneticModel.Puzzle = testPuzzle;

            return geneticModel;
        }
    }
    public static GeneticModel Medium
    {
        get
        {
            var geneticModel = new GeneticModel();
            var testPuzzle = new int[9][];
            testPuzzle[0] = new int[] { 0, 6, 9, 3, 0, 0, 0, 8, 0 };
            testPuzzle[1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0 };
            testPuzzle[2] = new int[] { 0, 0, 0, 6, 7, 0, 0, 0, 0 };
            testPuzzle[3] = new int[] { 1, 2, 0, 0, 0, 0, 0, 7, 0 };
            testPuzzle[4] = new int[] { 7, 0, 5, 0, 0, 0, 0, 0, 0 };
            testPuzzle[5] = new int[] { 3, 9, 6, 0, 0, 0, 2, 8, 0 };
            testPuzzle[6] = new int[] { 0, 0, 2, 7, 3, 0, 8, 1, 0 };
            testPuzzle[7] = new int[] { 3, 0, 0, 5, 0, 0, 0, 2, 9 };
            testPuzzle[8] = new int[] { 4, 1, 0, 9, 0, 8, 0, 0, 0 };

            geneticModel.Puzzle = testPuzzle;

            return geneticModel;
        }
    }
    public static GeneticModel Hard
    {
        get
        {
            var geneticModel = new GeneticModel();
            var testPuzzle = new int[9][];
            testPuzzle[0] = new int[] { 0, 0, 1, 0, 0, 0, 4, 0, 6 };
            testPuzzle[1] = new int[] { 0, 0, 5, 0, 0, 9, 3, 0, 0 };
            testPuzzle[2] = new int[] { 0, 0, 4, 0, 0, 6, 0, 0, 8 };
            testPuzzle[3] = new int[] { 0, 0, 0, 0, 0, 7, 0, 0, 4 };
            testPuzzle[4] = new int[] { 0, 0, 0, 0, 8, 0, 0, 0, 3 };
            testPuzzle[5] = new int[] { 0, 0, 0, 0, 0, 1, 5, 0, 0 };
            testPuzzle[6] = new int[] { 0, 0, 3, 0, 7, 0, 9, 6, 0 };
            testPuzzle[7] = new int[] { 0, 0, 7, 9, 0, 0, 0, 0, 0 };
            testPuzzle[8] = new int[] { 2, 0, 0, 1, 0, 0, 0, 0, 0 };

            geneticModel.Puzzle = testPuzzle;

            return geneticModel;
        }
    }
    public static GeneticModel EasyKiller
    {
        get
        {
            var geneticModel = new GeneticModel();
            var testPuzzle = new int[9][];
            testPuzzle[0] = new int[] { 0, 5, 0, 0, 0, 3, 6, 0, 0 };
            testPuzzle[1] = new int[] { 0, 0, 0, 0, 8, 0, 0, 5, 4 };
            testPuzzle[2] = new int[] { 0, 4, 0, 2, 5, 9, 8, 7, 0 };
            testPuzzle[3] = new int[] { 0, 0, 0, 0, 3, 0, 0, 0, 0 };
            testPuzzle[4] = new int[] { 0, 7, 2, 4, 1, 5, 0, 0, 8 };
            testPuzzle[5] = new int[] { 0, 0, 0, 0, 2, 0, 4, 0, 0 };
            testPuzzle[6] = new int[] { 0, 8, 4, 0, 0, 0, 0, 1, 5 };
            testPuzzle[7] = new int[] { 9, 6, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[8] = new int[] { 0, 3, 7, 0, 0, 2, 0, 0, 0 };
            geneticModel.Puzzle = testPuzzle;
            var killerValues = new Dictionary<int[][], int>();
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

            geneticModel.KillerValue = killerValues;

            return geneticModel;
        }
    }

    public static GeneticModel MediumKiller
    {
        get
        {
            var geneticModel = new GeneticModel();
            var testPuzzle = new int[9][];
            testPuzzle[0] = new int[] { 0, 0, 1, 0, 0, 0, 7, 0, 0 };
            testPuzzle[1] = new int[] { 5, 0, 9, 3, 0, 0, 0, 0, 0 };
            testPuzzle[2] = new int[] { 2, 3, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[3] = new int[] { 2, 5, 0, 0, 0, 0, 0, 6, 0 };
            testPuzzle[4] = new int[] { 0, 0, 0, 0, 0, 5, 0, 9, 2 };
            testPuzzle[5] = new int[] { 7, 0, 0, 0, 0, 2, 0, 0, 0 };
            testPuzzle[6] = new int[] { 0, 0, 0, 0, 0, 8, 5, 0, 0 };
            testPuzzle[7] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[8] = new int[] { 4, 0, 0, 0, 7, 1, 0, 0, 0 };
            geneticModel.Puzzle = testPuzzle;
            var killerValues = new Dictionary<int[][], int>();
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
            geneticModel.KillerValue = killerValues;
            return geneticModel;
        }
    }
    public static GeneticModel HardKiller
    {
        get
        {
            var geneticModel = new GeneticModel();
            var testPuzzle = new int[9][];
            testPuzzle[0] = new int[] { 0, 0, 0, 2, 0, 0, 0, 7, 0 };
            testPuzzle[1] = new int[] { 0, 7, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[2] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[3] = new int[] { 0, 0, 0, 0, 5, 8, 0, 0, 0 };
            testPuzzle[4] = new int[] { 0, 0, 5, 0, 0, 0, 0, 0, 0 };
            testPuzzle[5] = new int[] { 0, 0, 8, 0, 0, 9, 0, 0, 5 };
            testPuzzle[6] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[7] = new int[] { 5, 6, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[8] = new int[] { 0, 0, 7, 0, 5, 1, 0, 3, 0 };
            geneticModel.Puzzle = testPuzzle;
            var killerValues = new Dictionary<int[][], int>();
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
            geneticModel.KillerValue = killerValues;

            return geneticModel;
        }
    }
    public static GeneticModel KillerKiller
    {
        get
        {
            var geneticModel = new GeneticModel();
            var testPuzzle = new int[9][];
            testPuzzle[0] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[2] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[3] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[4] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[5] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[6] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[7] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            testPuzzle[8] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            geneticModel.Puzzle = testPuzzle;
            var killerValues = new Dictionary<int[][], int>();
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
            geneticModel.KillerValue = killerValues;

            return geneticModel;
        }
    }
}

public class GeneticModel
{
    public Dictionary<int[][], int> KillerValue { get; set; } = default!;
    public int[][] Puzzle { get; set; } = default!;
}