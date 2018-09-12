using UnityEngine;
using UnityEngine.UI;

public static class UIManager
{
    private static GameObject textToGuess;

    public static void Init()
    {
        textToGuess = GameObject.Find("TextToGuess");

        textToGuess.GetComponent<Text>().text = PhraseHelper.GetRandomPhrase();
    }
}