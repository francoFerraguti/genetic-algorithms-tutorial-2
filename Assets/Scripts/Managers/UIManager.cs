using UnityEngine;
using UnityEngine.UI;

public static class UIManager
{
    private static GameObject phraseToGuess;

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
            int posX = 480;
            int posY = 280 - 25 * i;

            Vector3 position = new Vector3(posX, posY, 0);
            Quaternion rotation = new Quaternion(0, 0, 0, 0);

            GameObject individual = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Individual"), position, rotation);
            individual.transform.SetParent(GameObject.Find("Canvas").transform, false);
        }
    }
}