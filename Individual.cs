using System;
using System.Collections.Generic;
using System.Text;

namespace NQueens
{
    public class Individual
    {
        public int[] chromosome;
        public int fitness;
        public int boardSize;

        public Individual(int boardSize)
        {
            this.boardSize = boardSize;
            this.chromosome = new int[boardSize];
        }

        internal void CalculateFitness()
        {
            int partialFitness = (boardSize * (boardSize - 1)) / 2;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (i != j)
                    {
                        int dx = Math.Abs(i - j);
                        int dy = Math.Abs(chromosome[i] - chromosome[j]);
                        if (dx == dy)
                        {
                            partialFitness--;
                        }
                    }
                }
            }
            fitness = partialFitness;
        }
    }
}
