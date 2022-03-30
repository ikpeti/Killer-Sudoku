using System;
using System.Collections.Generic;
using System.Text;

namespace Killer_Sudoku_2
{
    public class GeneticAlgorithm<T>
    {
        public List<Chromosome<T>> Population { get; private set; }
        public int Generation { get; private set; }
        public double BestFitness { get; private set; }
        public T[] BestGenes { get; private set; }

        public int Elitism;
        public double MutationRate;

        private List<Chromosome<T>> newPopulation;
        private Random random;
        private double fitnessSum;

        public GeneticAlgorithm(int populationSize, int geneSize, Random r, Func<T> getRandomGene, Func<int, double> fitnessFunction, 
            int elitism = 20, double mutationRate = 0.3)
        {
            Population = new List<Chromosome<T>>(populationSize);
            newPopulation = new List<Chromosome<T>>(populationSize);
            Generation = 1;
            Elitism = elitism;
            MutationRate = mutationRate;
            random = r;
            BestGenes = new T[geneSize];
            BestFitness = 1000000;

            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new Chromosome<T>(geneSize, r, getRandomGene, fitnessFunction, firstTime : true));
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
                    Chromosome<T> parent1 = chooseParent();
                    Chromosome<T> parent2 = chooseParent();

                    Chromosome<T> child = parent1.Crossover(parent2);

                    child.Mutate(MutationRate);

                    newPopulation.Add(child);
                }
            }

            List<Chromosome<T>> tmp = Population;
            Population = newPopulation;
            newPopulation = tmp;

            Generation++;
        }

        public int CompareChromosomes(Chromosome<T> a, Chromosome<T> b)
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

            Chromosome<T> best = Population[0];

            for (int i = 0; i < Population.Count; i++)
            {
                fitnessSum -= Population[i].CalculateFitness(i);

                if (Population[i].Fitness < best.Fitness)
                    best = Population[i];
            }

            BestFitness = best.Fitness;
            best.Genes.CopyTo(BestGenes, 0);
        }

        private Chromosome<T> chooseParent()
        {
            double randomNumber = random.NextDouble() * fitnessSum;

            for (int i = 0; i < Population.Count; i++)
            {
                if (randomNumber < Population[i].Fitness)
                    return Population[i];

                randomNumber += Population[i].Fitness;
            }

            return null;
        }
    }
}
