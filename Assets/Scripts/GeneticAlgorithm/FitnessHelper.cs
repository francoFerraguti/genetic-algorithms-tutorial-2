using System.Collections.Generic;
using UnityEngine;

public static class FitnessHelper
{
    public static void CalculateFitness(List<GameObject> population)
    {
        for (int i = 0; i < population.Count; i++)
        {
            population[i].GetComponent<Individual>().CalculateFitness();
        }
    }

    public static Vector3 GetFitnessInformation(List<GameObject> population)
    {
        Vector3 fitnesses = new Vector3(int.MinValue, 0, int.MaxValue);

        for (int i = 0; i < population.Count; i++)
        {
            int currentFitness = population[i].GetComponent<Individual>().fitness;

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

    public static int GetPopulationTotalFitness(List<GameObject> population)
    {
        int totalFitness = 0;

        for (int i = 0; i < population.Count; i++)
        {
            totalFitness += population[i].GetComponent<Individual>().fitness;
        }

        return totalFitness;
    }

    public static List<GameObject> GetIndividualsWithHighestFitness(List<GameObject> population, int nIndividuals)
    {
        List<GameObject> populationCopy = PopulationHelper.CopyPopulation(population);
        List<GameObject> individualsWithHighestFitness = new List<GameObject>();

        for (int i = 0; i < nIndividuals; i++)
        {
            GameObject individualWithHighestFitness = populationCopy[0];

            for (int j = 1; j < populationCopy.Count; j++)
            {
                if (populationCopy[j].GetComponent<Individual>().fitness > individualWithHighestFitness.GetComponent<Individual>().fitness)
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