using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillerSudoku
{
    public class Fitness_Four : IFitness
    {
        private int[,] board;

        public Fitness_Four(int[,] b)
        {
            board = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = b[i, j];
                }
            }
        }
        public double Evaluate(IChromosome chromosome)
        {
            Chromosome_Four chrom = (Chromosome_Four)chromosome;

            double ev = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(board[i,j] != 0)
                    {
                        if (board[i, j] != chrom.board[i, j])
                            return ev;
                    }
                }
            }

            int countX = 0;
            int countY = 0;
            for (int i = 0; i < 4; i++)
            {
                countX = chrom.board[i, 0] + chrom.board[i, 1] + chrom.board[i, 2] + chrom.board[i, 3];
                countY = chrom.board[0, i] + chrom.board[1, i] + chrom.board[2, i] + chrom.board[3, i];
                if (countX == 10)
                    ev += 1000;
                if (countY == 10)
                    ev += 1000;
            }

            return ev;
        }
    }
}
