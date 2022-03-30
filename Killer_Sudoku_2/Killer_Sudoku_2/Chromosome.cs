using System;
using System.Collections.Generic;
using System.Text;

namespace Killer_Sudoku_2
{
    public class Chromosome<T>
    {
        public T[] Genes { get; private set; }
        public double Fitness { get; private set; }
        private Random random;
        private Func<T> getRandomGene;
        Func<int, double> fitnessFunction;
        public Chromosome(int size, Random r, Func<T> getRandomGene, Func<int, double> fitnessFunction, bool firstTime = true)
        {
            Genes = new T[size];
            random = r;
            this.getRandomGene = getRandomGene;
            this.fitnessFunction = fitnessFunction;

            if (firstTime)
            {
                for (int i = 0; i < Genes.Length; i++)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }

        public double CalculateFitness(int index)
        {
            Fitness = fitnessFunction(index);
            return Fitness;
        }

        public Chromosome<T> Crossover(Chromosome<T> otherParent)
        {
            Chromosome<T> child = new Chromosome<T>(Genes.Length, random, getRandomGene, fitnessFunction, firstTime : false);

            for (int i = 0; i < Genes.Length; i++)
            {
                child.Genes[i] = random.NextDouble() < 0.5 ? Genes[i] : otherParent.Genes[i];
            }

            return child;
        }

        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if(random.NextDouble() < mutationRate)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }
    }
}
