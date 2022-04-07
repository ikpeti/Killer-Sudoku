using System;
using System.Collections.Generic;
using System.Text;

namespace Killer_Sudoku_2
{
    public class Chromosome
    {
        public int[][] Genes { get; private set; }
        public int[][] SudokuProblem { get; private set; }
        public double Fitness { get; private set; }
        private Random random;
        private Action<int[][]> getRandomGenes;
        private Func<int, double> fitnessFunction;
        public Chromosome(int size, int[][] sudoku, Random r, Action<int[][]> getRandomGenes, Func<int, double> fitnessFunction, bool firstTime = true)
        {
            Genes = new int[size][];
            for (int i = 0; i < size; i++)
            {
                Genes[i] = new int[size];
            }
            SudokuProblem = sudoku;
            random = r;
            this.getRandomGenes = getRandomGenes;
            this.fitnessFunction = fitnessFunction;

            if (firstTime)
            {
                getRandomGenes(Genes);
            }
        }

        public double CalculateFitness(int index)
        {
            Fitness = fitnessFunction(index);
            return Fitness;
        }

        public Chromosome Crossover(Chromosome otherParent)
        {
            Chromosome child = new Chromosome(Genes.Length, SudokuProblem, random, getRandomGenes, fitnessFunction, firstTime : false);

            for (int i = 0; i < Genes.Length; i++)
            {
                child.Genes[i] = random.NextDouble() < 0.5 ? Genes[i] : otherParent.Genes[i];
            }

            return child;
        }

        public void Mutate(double mutationRate)
        {
            int[][] indexes = new int[Genes.Length][];

            for (int i = 0; i < Genes.Length; i++)
            {
                if (random.NextDouble() < mutationRate)
                {
                    int a = random.Next(0, Genes.Length);
                    int b = random.Next(0, Genes.Length);

                    if (SudokuProblem[i][a] != 0 || SudokuProblem[i][b] != 0)
                        return;

                    indexes[i] = new int[] { a, b };
                }
                else
                    indexes[i] = new int[] { 0 };
            }

            for (int i = 0; i < Genes.Length; i++)
            {
                if(indexes[i][0] != 0)
                {
                    int tmp = Genes[i][indexes[i][0]];
                    Genes[i][indexes[i][0]] = Genes[i][indexes[i][1]];
                    Genes[i][indexes[i][1]] = tmp;
                }
            }
        }
    }
}
