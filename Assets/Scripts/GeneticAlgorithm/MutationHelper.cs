using System.Collections.Generic;
using UnityEngine;

public static class MutationHelper
{

    private static System.Random rand;

    public static void Init()
    {
        rand = new System.Random();
    }

    public static void MutatePopulation(List<Individual> population)
    {
        for (int i = 0; i < population.Count; i++)
        {
            MutateIndividual(population[i]);
        }
    }

    private static void MutateIndividual(Individual individual)
    {
        string currentPhrase = individual.dna.phrase;
        string newPhrase = "";

        for (int i = 0; i < currentPhrase.Length; i++)
        {
            newPhrase += (rand.Next(0, 10000) < Config.mutationRate * 100) ? PhraseHelper.GetRandomLetter() : currentPhrase[i];
        }

        individual.dna.phrase = newPhrase;
    }
}