using System.Collections.Generic;
using UnityEngine;

public static class FitnessHelper
{
    public static void CalculateFitness(List<Individual> population)
    {
        for (int i = 0; i < population.Count; i++)
        {
            population[i].CalculateFitness();
        }
    }

    public static Vector3 GetFitnessInformation(List<Individual> population)
    {
        Vector3 fitnesses = new Vector3(int.MinValue, 0, int.MaxValue);

        for (int i = 0; i < population.Count; i++)
        {
            int currentFitness = population[i].fitness;

            if (currentFitness > fitnesses.x)
            {
                fitnesses.x = currentFitness;
            }
            if (currentFitness < fitnesses.z)
            {
                fitnesses.z = currentFitness;
            }

            fitnesses.y += currentFitness;
        }

        fitnesses.y /= population.Count;

        return fitnesses;
    }

    public static int GetPopulationTotalFitness(List<Individual> population)
    {
        int totalFitness = 0;

        for (int i = 0; i < population.Count; i++)
        {
            totalFitness += population[i].fitness;
        }

        return totalFitness;
    }

    public static List<Individual> GetIndividualsWithHighestFitness(List<Individual> population, int nIndividuals)
    {
        List<Individual> populationCopy = PopulationHelper.CopyPopulation(population);
        List<Individual> individualsWithHighestFitness = new List<Individual>();

        for (int i = 0; i < nIndividuals; i++)
        {
            Individual individualWithHighestFitness = populationCopy[0];

            for (int j = 1; j < populationCopy.Count; j++)
            {
                if (populationCopy[j].fitness > individualWithHighestFitness.fitness)
                {
                    individualWithHighestFitness = populationCopy[j];
                }
            }

            individualsWithHighestFitness.Add(individualWithHighestFitness);
            populationCopy.Remove(individualWithHighestFitness);
        }

        return individualsWithHighestFitness;
    }
}