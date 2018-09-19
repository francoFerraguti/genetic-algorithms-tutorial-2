using System.Collections.Generic;
using UnityEngine;

public static class PopulationHelper
{
    public static List<Individual> CopyPopulation(List<Individual> population)
    {
        List<Individual> populationCopy = new List<Individual>();

        for (int i = 0; i < population.Count; i++)
        {
            populationCopy.Add(population[i]);
        }

        return populationCopy;
    }
}