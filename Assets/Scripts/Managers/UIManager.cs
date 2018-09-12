using UnityEngine;
using UnityEngine.UI;

public static class UIManager
{
    private static GameObject phraseToGuess;

    private static int posX = 480;
    private static int initialY = 280;
    private static int incrementalY = 25;

    public static void Init()
    {
        CreatePhraseToGuess();
        CreateIndividuals(Config.nIndividuals);
    }

    public static void CreatePhraseToGuess()
    {
        phraseToGuess = GameObject.Find("PhraseToGuess");
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

    public static void UpdateIndividuals()
    {
        GameObject[] individuals = GameObject.FindGameObjectsWithTag("Individual");

        for (int i = 0; i < individuals.Length; i++)
        {
            individuals[i].GetComponent<Text>().text = individuals[i].GetComponent<Individual>().dna.phrase;
        }
    }
}