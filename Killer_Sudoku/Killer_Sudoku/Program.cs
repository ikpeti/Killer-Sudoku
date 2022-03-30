using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;

namespace KillerSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Size:");
            SudokuBoard sb = new SudokuBoard(Convert.ToInt32(Console.ReadLine()));
            sb.ReadInput();
            sb.ShowBoard();

            var selection = new EliteSelection();
            var crossover = new UniformCrossover(0.5f);
            var mutation = new ReverseSequenceMutation();
            var fitness = new Fitness_Four(sb.GetBoard());
            var chromosome = new Chromosome_Four(sb.GetBoard());
            var population = new Population(50, 70, chromosome);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new FitnessStagnationTermination(1000);

            Console.WriteLine("GA running...");
            ga.Start();

            Console.WriteLine("Best solution found has {0} fitness.", ga.BestChromosome.Fitness);

            Chromosome_Four result = (Chromosome_Four)ga.BestChromosome;

            for (int i = 0; i < 4; i++)
            {
                if (i == 2)
                {
                    Console.WriteLine("---------");
                }
                for (int j = 0; j < 4; j++)
                {
                    if (j == 2)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(result.board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
