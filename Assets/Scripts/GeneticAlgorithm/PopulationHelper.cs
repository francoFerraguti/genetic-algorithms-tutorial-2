using System.Collections.Generic;
using UnityEngine;

public static class PopulationHelper
{
    public static List<GameObject> CopyPopulation(List<GameObject> population)
    {
        List<GameObject> populationCopy = new List<GameObject>();

        for (int i = 0; i < population.Count; i++)
        {
            populationCopy.Add(population[i]);
        }

        return populationCopy;
    }
}