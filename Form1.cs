using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NQueens
{
    public partial class Form1 : Form
    {
        int numberOfQueensForOutput;
        int recombinationProbabilityForOutput;
        int mutationProbabilityForOutput;
        int populationSizeForOutput;
        int maximumNumberOfGenerationsForOutput;

        private static Random rng = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int numberOfQueens = Convert.ToInt32(Math.Round(NumberOfQueensUpDown.Value, 0));
            if (numberOfQueens < 8 || numberOfQueens > 12)
            {
                MessageBox.Show("Invalid Number of Queens!");
                return;
            }
            numberOfQueensForOutput = numberOfQueens;

            if (!isProbabilityValid(Convert.ToInt32(Math.Round(RecombinationProbabilityUpDown.Value, 0))))
            {
                MessageBox.Show("Invalid Recombination Probability!");
                return;
            }
            int recombinationProbability = Convert.ToInt32(Math.Round(RecombinationProbabilityUpDown.Value, 0));
            recombinationProbabilityForOutput = recombinationProbability;

            if (!isProbabilityValid(Convert.ToInt32(Math.Round(MutationProbabilityUpDown.Value, 0))))
            {
                MessageBox.Show("Invalid Mutation Probability!");
                return;
            }
            int mutationProbability = Convert.ToInt32(Math.Round(MutationProbabilityUpDown.Value, 0));
            mutationProbabilityForOutput = mutationProbability;

            int populationSize;
            bool isValidPopulationSize = int.TryParse(PopulationSizeTextBox.Text, out populationSize);
            if (!isValidPopulationSize || populationSize < 5)
            {
                MessageBox.Show("Invalid Population Size! Population should have at least 5 individuals");
                return;
            }
            populationSizeForOutput = populationSize;

            int maximumNumberOfGenerations;
            bool isValidNumberOfGenerations = int.TryParse(MaxGenerationsTextbox.Text, out maximumNumberOfGenerations);
            if(!isValidNumberOfGenerations || maximumNumberOfGenerations < 1)
            {
                MessageBox.Show("Invalid Maximum Number of Generations");
                return;
            }
            maximumNumberOfGenerationsForOutput = maximumNumberOfGenerations;

            List<object> parameters = new List<object>();
            parameters.Add(numberOfQueens);
            parameters.Add(recombinationProbability);
            parameters.Add(mutationProbability);
            parameters.Add(populationSize);
            parameters.Add(maximumNumberOfGenerations);
            GeneticAlgorithmBackgroundWorker.RunWorkerAsync(parameters);
        }

        private bool isProbabilityValid(int probability)
        {
            return 0 <= probability && probability <= 100;
        }

        private void GeneticAlgorithmBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> parameters = (List<object>)e.Argument;
            int numberOfQueens = (int)parameters[0];
            int recombinationProbability = (int)parameters[1];
            int mutationProbability = (int)parameters[2];
            int populationSize = (int)parameters[3];
            int maxGenerations = (int)parameters[4];

            List<Individual> individuals = GetInitialPopulation(numberOfQueens, populationSize);

            for(int i = 0; i < maxGenerations; i++)
            {
                List<Individual> totalDescendants = new List<Individual>();
                while (totalDescendants.Count < populationSize)
                {
                    List<Individual> parents = SelectParents(populationSize, individuals, numberOfQueens);
                    parents.Sort(new IndividualComparer());

                    int recombinationRandom = rng.Next(101);
                    Individual firstOffspring = null;
                    Individual secondOffspring = null;
                    if (recombinationRandom < recombinationProbability)
                    {
                        List<Individual> offspring = GenerateOffspring(parents[0], parents[1]);
                        firstOffspring = offspring[0];
                        secondOffspring = offspring[1];
                    }
                    else
                    {
                        firstOffspring = CopyIndividual(parents[0], true);
                        secondOffspring = CopyIndividual(parents[1], true);
                    }
                    Mutate(firstOffspring, mutationProbability);
                    Mutate(secondOffspring, mutationProbability);

                    totalDescendants.Add(firstOffspring);
                    totalDescendants.Add(secondOffspring);
                }
                for(int k = 0; k < totalDescendants.Count; k++)
                {
                    totalDescendants[k].CalculateFitness();
                }
                totalDescendants.Sort(new IndividualComparer());
                while(totalDescendants.Count > populationSize)
                {
                    totalDescendants.RemoveAt(totalDescendants.Count - 1);
                }
                individuals = totalDescendants;
                int percentage = (i + 1) * 100 / maxGenerations;
                GeneticAlgorithmBackgroundWorker.ReportProgress(percentage);
            }
            e.Result = individuals;
            GenerateFile(individuals);
        }

        private void GenerateFile(List<Individual> individuals)
        {
            using (StreamWriter writer = new StreamWriter("result_Q_" + numberOfQueensForOutput +
                "_R_" + recombinationProbabilityForOutput + 
                "_M_" + mutationProbabilityForOutput + 
                "_P_" + populationSizeForOutput + 
                "_MAX_GEN_" + maximumNumberOfGenerationsForOutput + ".txt"))
            {
                writer.WriteLine("Number Of Queens: " + numberOfQueensForOutput);
                writer.WriteLine("Recombination Probability: " + recombinationProbabilityForOutput);
                writer.WriteLine("Mutation Probability: " + mutationProbabilityForOutput);
                writer.WriteLine("Population Size: " + populationSizeForOutput);
                writer.WriteLine("Maximum Number Of Generations: " + maximumNumberOfGenerationsForOutput);
                for(int i = 0; i < individuals.Count; i++)
                {
                    writer.Write(i + ". Chromosome: ");
                    for(int j = 0; j < individuals[i].boardSize; j++)
                    {
                        writer.Write(individuals[i].chromosome[j] + " ");
                    }
                    writer.WriteLine("Fitness: " + individuals[i].fitness);
                }
            }
        }

        private void Mutate(Individual firstOffspring, int mutationProbability)
        {
            int random = rng.Next(101);
            if(random < mutationProbability)
            {
                int firstPosition = rng.Next(firstOffspring.boardSize);
                int secondPosition = rng.Next(firstOffspring.boardSize);
                while(secondPosition == firstPosition)
                {
                    secondPosition = rng.Next(firstOffspring.boardSize);
                }
                int t;
                t = firstOffspring.chromosome[firstPosition];
                firstOffspring.chromosome[firstPosition] = firstOffspring.chromosome[secondPosition];
                firstOffspring.chromosome[secondPosition] = t;
            }
        }

        private List<Individual> GenerateOffspring(Individual firstIndividual, Individual secondIndividual)
        {
            int cutPoint = rng.Next(1, firstIndividual.boardSize - 1);

            List<Individual> offspring = new List<Individual>();
            Individual firstOffspring = new Individual(firstIndividual.boardSize);
            firstOffspring.boardSize = firstIndividual.boardSize;

            Individual secondOffspring = new Individual(firstIndividual.boardSize);
            secondOffspring.boardSize = firstIndividual.boardSize;

            List<int> remainingInFirst = new List<int>();
            List<int> remainingInSecond = new List<int>();

            for(int i = 0; i < firstIndividual.boardSize; i++)
            {
                remainingInFirst.Add(i);
                remainingInSecond.Add(i);
            }

            for(int i = 0; i < cutPoint; i++)
            {
                firstOffspring.chromosome[i] = firstIndividual.chromosome[i];
                remainingInFirst.Remove(firstIndividual.chromosome[i]);
                secondOffspring.chromosome[i] = secondIndividual.chromosome[i];
                remainingInSecond.Remove(secondIndividual.chromosome[i]);
            }

            int pos1 = cutPoint;
            int pos2 = cutPoint;
            for(int i = cutPoint; i < firstIndividual.boardSize; i++)
            {
                if(remainingInFirst.Contains(secondIndividual.chromosome[i]))
                {
                    firstOffspring.chromosome[pos1] = secondIndividual.chromosome[i];
                    remainingInFirst.Remove(secondIndividual.chromosome[i]);
                    pos1++;
                }

                if (remainingInSecond.Contains(firstIndividual.chromosome[i]))
                {
                    secondOffspring.chromosome[pos2] = firstIndividual.chromosome[i];
                    remainingInSecond.Remove(firstIndividual.chromosome[i]);
                    pos2++;
                }
            }

            for(int i = pos1; i < firstIndividual.boardSize; i++)
            {
                firstOffspring.chromosome[i] = remainingInFirst[0];
                remainingInFirst.RemoveAt(0);
            }

            for(int i = pos2; i < firstIndividual.boardSize; i++)
            {
                secondOffspring.chromosome[i] = remainingInSecond[0];
                remainingInSecond.RemoveAt(0);
            }

            offspring.Add(firstOffspring);
            offspring.Add(secondOffspring);
            return offspring;
        }

        private List<Individual> GetInitialPopulation(int numberOfQueens, int populationSize)
        {
            List<Individual> individuals = new List<Individual>();
            for (int i = 0; i < populationSize; i++)
            {
                int[] shuffledArray =  GetShuffledArray(numberOfQueens);
                Individual individual = new Individual(numberOfQueens);
                individual.chromosome = shuffledArray;
                individual.CalculateFitness();
                individuals.Add(individual);
            }
            return individuals;
        }

        private int[] GetShuffledArray(int numberOfQueens)
        {
            int[] array = new int[numberOfQueens];
            for (int j = 0; j < numberOfQueens; j++)
            {
                array[j] = j;
            }

            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);

                int firstValue = array[k];
                array[k] = array[n];
                array[n] = firstValue;
            }
            return array;
        }

        private List<Individual> SelectParents(int populationSize, List<Individual> individuals, int numberOfQueens)
        {
            List<Individual> parents = new List<Individual>();
            List<int> chosenIDs = new List<int>();
            for(int i = 0; i < 5; i++)
            {
                int randomNumber = rng.Next(populationSize);
                while(chosenIDs.Contains(randomNumber))
                {
                    randomNumber = rng.Next(populationSize);
                }

                chosenIDs.Add(randomNumber);
                Individual indi = individuals[randomNumber];
                Individual newIndividual = new Individual(indi.boardSize);
                int[] copyOfChromosomes = new int[numberOfQueens];
                for (int j = 0; j < numberOfQueens; j++)
                {
                    copyOfChromosomes[j] = indi.chromosome[j];
                }
                newIndividual.chromosome = copyOfChromosomes;
                newIndividual.fitness = indi.fitness;
                parents.Add(newIndividual);
            }
            return parents;
        }
        private Individual CopyIndividual(Individual individual, bool withFitness)
        {
            Individual copy = new Individual(individual.boardSize);

            int[] newChromosome = new int[individual.boardSize];
            for (int i = 0; i < individual.boardSize; i++)
            {
                newChromosome[i] = individual.chromosome[i];
            }
            copy.chromosome = newChromosome;

            if (withFitness)
            {
                copy.fitness = individual.fitness;
            }
            return individual;
        }

        private void GeneticAlgorithmBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }

    public class IndividualComparer : IComparer<Individual>
    {
        public int Compare(Individual x, Individual y)
        {
            return y.fitness - x.fitness;
        }
    }

    
}
