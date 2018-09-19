using System.Collections.Generic;
using UnityEngine;

public static class MutationHelper
{

    private static System.Random rand;

    public static void Init()
    {
        rand = new System.Random();
    }

    public static void MutatePopulation(List<GameObject> population)
    {
        for (int i = 0; i < population.Count; i++)
        {
            MutateIndividual(population[i]);
        }
    }

    private static void MutateIndividual(GameObject individual)
    {
        string currentPhrase = individual.GetComponent<Individual>().dna.phrase;
        string newPhrase = "";

        for (int i = 0; i < currentPhrase.Length; i++)
        {
            newPhrase += (rand.Next(0, 10000) < Config.mutationRate * 100) ? PhraseHelper.GetRandomLetter() : currentPhrase[i];
        }

        individual.GetComponent<Individual>().dna.phrase = newPhrase;
    }
}