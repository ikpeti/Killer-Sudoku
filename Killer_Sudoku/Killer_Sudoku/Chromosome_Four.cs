using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillerSudoku
{
    public class Chromosome_Four : ChromosomeBase
    {
        public int[,] board;

        public Chromosome_Four(int[,] b) : base(10)
        {
            board = b;
            CreateGenes();
        }
        public override IChromosome CreateNew()
        {
            return new Chromosome_Four(board);
        }

        public override Gene GenerateGene(int geneIndex)
        {
            int[] tri = new int[4];
            for (int i = 0; i < 4; i++)
            {
                tri[i] = RandomizationProvider.Current.GetInt(0, 4);
            }
            return new Gene(tri);
        }
    }
}
