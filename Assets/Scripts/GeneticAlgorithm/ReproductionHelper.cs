using System;
using System.Collections.Generic;
using UnityEngine;

public static class ReproductionHelper
{
    private static System.Random rand;

    public static void Init()
    {
        rand = new System.Random();
    }

    public static List<GameObject> GetNewIndividuals(List<GameObject> population, int nIndividuals)
    {
        List<GameObject> childrenIndividuals = new List<GameObject>();

        for (int i = 0; i < nIndividuals; i++)
        {
            GameObject parent1 = SpinRoulette(population);
            GameObject parent2 = SpinRoulette(population, parent1);
        }

        return childrenIndividuals;
    }

    private static GameObject SpinRoulette(List<GameObject> population, GameObject alreadySelectedIndividual = null)
    {
        int totalFitness = FitnessHelper.GetPopulationTotalFitness(population);
        int rouletteResult = rand.Next(0, totalFitness);
        int portionCounter = 0;

        for (int i = 0; i < population.Count; i++)
        {
            portionCounter += population[i].GetComponent<Individual>().fitness;

            if (portionCounter > rouletteResult)
            {
                return (alreadySelectedIndividual == population[i]) ? SpinRoulette(population, alreadySelectedIndividual) : population[i];
            }
        }

        Debug.LogError("Error de ejecución de la ruleta, valores: " + totalFitness + " y " + rouletteResult);
        return null;
    }
}