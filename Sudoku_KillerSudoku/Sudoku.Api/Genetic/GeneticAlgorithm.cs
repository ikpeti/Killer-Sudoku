namespace Sudoku.Api.Genetic;
public class GeneticAlgorithm
{
    public List<Chromosome> Population { get; private set; }
    public int Generation { get; private set; }
    public double BestFitness { get; private set; }
    public int[][] BestGenes { get; private set; }

    public int Elitism;
    public double MutationRate;

    private List<Chromosome> newPopulation;
    private readonly Random random;

    public GeneticAlgorithm(int populationSize, int geneSize, Action<int[][]> getRandomGenes, Func<int, int> fitnessFunction,
        int elitism = 10, double mutationRate = 0.1)
    {
        Population = new List<Chromosome>(populationSize);
        newPopulation = new List<Chromosome>(populationSize);
        Generation = 1;
        Elitism = elitism;
        MutationRate = mutationRate;
        random = new Random();
        BestGenes = new int[geneSize][];
        for (int i = 0; i < BestGenes.Length; i++)
        {
            BestGenes[i] = new int[geneSize];
        }
        BestFitness = 1000000;

        for (int i = 0; i < populationSize; i++)
        {
            Population.Add(new Chromosome(geneSize, random, getRandomGenes, fitnessFunction, firstTime: true));
        }
    }

    public void NewGeneration()
    {
        CalculateFitness();

        Population.Sort(CompareChromosomes);
        newPopulation.Clear();

        for (int i = 0; i < Elitism; i++)
        {
            newPopulation.Add(Population[i]);
        }

        for (int i = Population.Count - 1; i >= Elitism; i--)
        {
            Chromosome parent1 = Selection(i);
            Chromosome parent2 = Selection(i);

            Chromosome child = parent1.Crossover(parent2);

            child.Mutate(MutationRate);

            newPopulation.Add(child);
        }

        (newPopulation, Population) = (Population, newPopulation);
        Generation++;
        if (Generation == 100)
            MutationRate = 0.9;
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
        Chromosome best = Population[0];

        for (int i = 0; i < Population.Count; i++)
        {
            Population[i].CalculateFitness(i);

            if (Population[i].Fitness < best.Fitness)
                best = Population[i];
        }

        BestFitness = best.Fitness;
        for (int i = 0; i < BestGenes.Length; i++)
        {
            best.Genes[i].CopyTo(BestGenes[i], 0);
        }
    }

    private Chromosome Selection(int i)
    {
        int x = (int)(i * random.NextDouble());
        return Population[x];
    }
}
