using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PopulationManager
{
    private static List<GameObject> population;
    private static int generationNumber = 0;

    public static void Init()
    {
        population = new List<GameObject>();
    }

    public static void AssignPopulation()
    {
        GameObject[] individuals = GameObject.FindGameObjectsWithTag("Individual");

        for (int i = 0; i < individuals.Length; i++)
        {
            individuals[i].GetComponent<Individual>().Init();
            population.Add(individuals[i]);
        }

        UIManager.UpdateIndividuals();
    }

    public static void AdvanceGeneration()
    {
        List<GameObject> newPopulation = new List<GameObject>();

        FitnessHelper.CalculateFitness(population);

        newPopulation.AddRange(FitnessHelper.GetIndividualsWithHighestFitness(population, Config.nIndividualsToAdvanceAutomatically));
        newPopulation.AddRange(ReproductionHelper.GetNewIndividuals(population, Config.nIndividuals - Config.nIndividualsToAdvanceAutomatically));
        MutationHelper.MutatePopulation(population);

        generationNumber++;

        UIManager.UpdateBestPhrase(newPopulation[0].GetComponent<Individual>().dna.phrase);
        UIManager.UpdateGenerationNumber(generationNumber);
        UIManager.UpdateFitnesses(FitnessHelper.GetFitnessInformation(population));
    }
}