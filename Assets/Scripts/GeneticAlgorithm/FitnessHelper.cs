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
}