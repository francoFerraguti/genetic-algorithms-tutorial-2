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

    public static List<GameObject> GetIndividualsWithHighestFitness(List<GameObject> population, int nIndividuals)
    {
        List<GameObject> individualsWithHighestFitness = new List<GameObject>();

        for (int i = 0; i < nIndividuals; i++)
        {
            GameObject individualWithHighestFitness = population[0];

            for (int j = 1; j < population.Count; j++)
            {
                if (population[j].GetComponent<Individual>().fitness > individualWithHighestFitness.GetComponent<Individual>().fitness)
                {
                    individualWithHighestFitness = population[j];
                }
            }

            individualsWithHighestFitness.Add(individualWithHighestFitness);
            population.Remove(individualWithHighestFitness);
        }

        return individualsWithHighestFitness;
    }
}