using System;
using System.Collections.Generic;
using System.Text;

namespace Killer_Sudoku_2
{
    public class GeneticAlgorithm
    {
        public List<Chromosome> Population { get; private set; }
        public int Generation { get; private set; }
        public double BestFitness { get; private set; }
        public int[][] BestGenes { get; private set; }

        public int Elitism;
        public double MutationRate;

        private List<Chromosome> newPopulation;
        private Random random;
        private double fitnessSum;

        public GeneticAlgorithm(int populationSize, int geneSize, int[][] sudoku, Random r, Action<int[][]> getRandomGenes, Func<int, double> fitnessFunction, 
            int elitism = 1, double mutationRate = 0.6)
        {
            Population = new List<Chromosome>(populationSize);
            newPopulation = new List<Chromosome>(populationSize);
            Generation = 1;
            Elitism = elitism;
            MutationRate = mutationRate;
            random = r;
            BestGenes = new int[geneSize][];
            BestFitness = 1000000;

            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new Chromosome(geneSize, sudoku, r, getRandomGenes, fitnessFunction, firstTime : true));
            }
        }

        public void NewGeneration()
        {
            if (Population.Count <= 0)
                return;

            CalculateFitness();

            Population.Sort(CompareChromosomes);
            newPopulation.Clear();

            for (int i = 0; i < Population.Count; i++)
            {
                if (i < Elitism)
                {
                    newPopulation.Add(Population[i]);
                }
                else
                {
                    Chromosome parent1 = chooseParent();
                    Chromosome parent2 = chooseParent();

                    Chromosome child = parent1.Crossover(parent2);

                    child.Mutate(MutationRate);

                    newPopulation.Add(child);
                }
            }

            List<Chromosome> tmp = Population;
            Population = newPopulation;
            newPopulation = tmp;

            Generation++;
        }

        public int CompareChromosomes(Chromosome a, Chromosome b)
        {
            if (a.Fitness < b.Fitness)
                return -1;
            else if (a.Fitness > b.Fitness)
                return 1;
            else
                return 0;
        }

        public void CalculateFitness()
        {
            fitnessSum = 0;

            Chromosome best = Population[0];

            for (int i = 0; i < Population.Count; i++)
            {
                fitnessSum -= Population[i].CalculateFitness(i);

                if (Population[i].Fitness < best.Fitness)
                    best = Population[i];
            }

            BestFitness = best.Fitness;
            best.Genes.CopyTo(BestGenes, 0);
        }

        private Chromosome chooseParent()
        {
            double randomNumber = random.NextDouble() * fitnessSum;

            for (int i = 0; i < Population.Count; i++)
            {
                if (randomNumber < Population[i].Fitness)
                    return Population[i];

                randomNumber += Population[i].Fitness;
            }
            Console.WriteLine("Pop Count: "+Population.Count);
            Console.WriteLine("FitnessSum: "+fitnessSum);
            return null;
        }
    }
}
