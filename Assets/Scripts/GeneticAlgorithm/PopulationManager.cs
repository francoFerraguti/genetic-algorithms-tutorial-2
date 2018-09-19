using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PopulationManager
{
    private static List<Individual> population;
    private static int generationNumber = 0;

    public static void Init()
    {
        population = new List<Individual>();
    }

    public static void AssignPopulation()
    {
        GameObject[] individuals = GameObject.FindGameObjectsWithTag("Individual");

        for (int i = 0; i < individuals.Length; i++)
        {
            population.Add(individuals[i].GetComponent<Individual>());
        }

        UIManager.UpdateIndividuals();
    }

    public static void ReassignPopulation(List<Individual> newPopulation)
    {
        GameObject[] individuals = GameObject.FindGameObjectsWithTag("Individual");

        for (int i = 0; i < individuals.Length; i++)
        {
            individuals[i].GetComponent<Individual>().Clean();
            individuals[i].GetComponent<Individual>().dna = newPopulation[i].dna;
        }

        UIManager.UpdateIndividuals();
    }

    public static void AdvanceGeneration()
    {
        List<Individual> newPopulation = new List<Individual>();

        FitnessHelper.CalculateFitness(population);

        newPopulation.AddRange(FitnessHelper.GetIndividualsWithHighestFitness(population, Config.nIndividualsToAdvanceAutomatically));

        UIManager.UpdateBestPhrase(newPopulation[0].dna.phrase);

        newPopulation.AddRange(ReproductionHelper.GetNewIndividuals(population, Config.nIndividuals - Config.nIndividualsToAdvanceAutomatically));
        MutationHelper.MutatePopulation(population);

        generationNumber++;

        UIManager.UpdateGenerationNumber(generationNumber);
        UIManager.UpdateFitnesses(FitnessHelper.GetFitnessInformation(population));

        ReassignPopulation(newPopulation);
    }
}