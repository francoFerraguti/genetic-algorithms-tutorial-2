using UnityEngine;
using UnityEngine.UI;

public static class UIManager
{
    private static GameObject phraseToGuess;
    private static GameObject bestPhrase;
    private static InfoPanel infoPanel;

    private static int posX = 480;
    private static int initialY = 280;
    private static int incrementalY = 25;

    public static void Init()
    {
        infoPanel = new InfoPanel();

        AssignVariables();
        CreatePhraseToGuess();
        CreateIndividuals(Config.nIndividuals);
    }

    private static void AssignVariables()
    {
        phraseToGuess = GameObject.Find("PhraseToGuess");
        bestPhrase = GameObject.Find("BestPhrase");
        infoPanel.generationNumber = GameObject.Find("InfoGenerationNumber");
        infoPanel.highestFitness = GameObject.Find("InfoHighestFitness");
        infoPanel.averageFitness = GameObject.Find("InfoAverageFitness");
        infoPanel.lowestFitness = GameObject.Find("InfoLowestFitness");
        infoPanel.totalPopulation = GameObject.Find("InfoTotalPopulation");
        infoPanel.mutationRate = GameObject.Find("InfoMutationRate");
        infoPanel.elitism = GameObject.Find("InfoElitism");

        infoPanel.totalPopulation.GetComponent<Text>().text = "Población total: " + Config.nIndividuals;
        infoPanel.mutationRate.GetComponent<Text>().text = "Porcentaje de mutación: " + Config.mutationRate;
        infoPanel.elitism.GetComponent<Text>().text = "Elitismo: " + Config.nIndividualsToAdvanceAutomatically;
    }

    public static void CreatePhraseToGuess()
    {
        phraseToGuess.GetComponent<Text>().text = PhraseHelper.GetRandomPhrase(Config.nLettersPerPhrase);
    }

    public static void CreateIndividuals(int nIndividuals)
    {
        for (int i = 0; i < nIndividuals; i++)
        {
            int posY = initialY - incrementalY * i;

            Vector3 position = new Vector3(posX, posY, 0);
            Quaternion rotation = new Quaternion(0, 0, 0, 0);

            GameObject individual = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Individual"), position, rotation);
            individual.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }
    }

    public static void UpdateBestPhrase(string newBestPhrase)
    {
        bestPhrase.GetComponent<Text>().text = newBestPhrase;
    }

    public static void UpdateGenerationNumber(int newGenerationNumber)
    {
        infoPanel.generationNumber.GetComponent<Text>().text = "Generación número: " + newGenerationNumber;
    }

    public static void UpdateFitnesses(Vector3 fitnesses)
    {
        infoPanel.highestFitness.GetComponent<Text>().text = "Mayor fitness: " + fitnesses.x;
        infoPanel.averageFitness.GetComponent<Text>().text = "Prom. fitness: " + fitnesses.y;
        infoPanel.lowestFitness.GetComponent<Text>().text = "Menor fitness: " + fitnesses.z;
    }

    public static void UpdateIndividuals()
    {
        GameObject[] individuals = GameObject.FindGameObjectsWithTag("Individual");

        for (int i = 0; i < individuals.Length; i++)
        {
            individuals[i].GetComponent<Text>().text = individuals[i].GetComponent<Individual>().dna.phrase;
        }
    }
}

public class InfoPanel
{
    public GameObject generationNumber;

    public GameObject highestFitness;
    public GameObject averageFitness;
    public GameObject lowestFitness;

    public GameObject totalPopulation;
    public GameObject mutationRate;
    public GameObject elitism;
}