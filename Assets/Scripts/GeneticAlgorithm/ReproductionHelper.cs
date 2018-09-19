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

    public static List<Individual> GetNewIndividuals(List<Individual> population, int nIndividuals)
    {
        List<Individual> childrenIndividuals = new List<Individual>();

        for (int i = 0; i < nIndividuals; i++)
        {
            Individual parent1 = SpinRoulette(population);
            Individual parent2 = SpinRoulette(population, parent1);
            childrenIndividuals.Add(Crossover(parent1, parent2));
        }

        return childrenIndividuals;
    }

    private static Individual Crossover(Individual parent1, Individual parent2)
    {
        Individual child = new Individual();
        child.dna.phrase = "";

        for (int i = 0; i < parent1.dna.phrase.Length; i++)
        {
            child.dna.phrase += (i % 2 == 0) ? parent1.dna.phrase[i] : parent2.dna.phrase[i];
        }

        return child;
    }

    private static Individual SpinRoulette(List<Individual> population, Individual alreadySelectedIndividual = null)
    {
        int totalFitness = FitnessHelper.GetPopulationTotalFitness(population);
        int rouletteResult = rand.Next(0, totalFitness);
        int portionCounter = 0;

        for (int i = 0; i < population.Count; i++)
        {
            portionCounter += population[i].fitness;

            if (portionCounter > rouletteResult)
            {
                return (alreadySelectedIndividual == population[i]) ? SpinRoulette(population, alreadySelectedIndividual) : population[i];
            }
        }

        Debug.LogError("Error de ejecución de la ruleta, valores: " + totalFitness + " y " + rouletteResult);
        return null;
    }
}