using System;
using System.Collections.Generic;
using System.Text;

namespace Killer_Sudoku_2
{
    public class Chromosome
    {
        public int[][] Genes { get; private set; }
        public int[][] SudokuProblem { get; private set; }
        public double Fitness { get; set; }
        private readonly Random random;
        private readonly Action<int[][]> getRandomGenes;
        private readonly Func<int, int> fitnessFunction;
        public Chromosome(int size, int[][] sudoku, Random r, Action<int[][]> getRandomGenes, Func<int, int> fitnessFunction, bool firstTime = true)
        {
            Genes = new int[size][];
            for (int i = 0; i < size; i++)
            {
                Genes[i] = new int[size];
            }
            SudokuProblem = sudoku;
            random = r;
            Fitness = 0;
            this.getRandomGenes = getRandomGenes;
            this.fitnessFunction = fitnessFunction;

            if (firstTime)
            {
                getRandomGenes(Genes);
            }
        }

        public void CalculateFitness(int index)
        {                
            Fitness = fitnessFunction(index);
        }

        public Chromosome Crossover(Chromosome otherParent)
        {
            Chromosome child = new Chromosome(Genes.Length, SudokuProblem, random, getRandomGenes, fitnessFunction, firstTime : false);

            for (int i = 0; i < Genes.Length; i++)
            {
                bool first = random.NextDouble() < 0.5;
                if(first)
                    Genes[i].CopyTo(child.Genes[i], 0);
                else
                    otherParent.Genes[i].CopyTo(child.Genes[i], 0);
            }

            return child;
        }

        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (random.NextDouble() < mutationRate)
                {
                    int a = random.Next(0, Genes.Length);
                    int b = random.Next(0, Genes.Length);

                    if (SudokuProblem[i][a] == 0 && SudokuProblem[i][b] == 0)
                        (Genes[i][b], Genes[i][a]) = (Genes[i][a], Genes[i][b]);
                }
            }
        }
    }
}
