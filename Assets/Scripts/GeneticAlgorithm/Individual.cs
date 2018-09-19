using UnityEngine;
using UnityEngine.UI;
public class Individual : MonoBehaviour
{
    public int fitness = 0;
    public DNA dna;

    public Individual()
    {
        dna = new DNA();
    }

    public void Clean()
    {
        fitness = 0;
        dna = new DNA();
    }

    public void CalculateFitness()
    {
        fitness = 0;
        string phraseToGuess = GameObject.Find("PhraseToGuess").GetComponent<Text>().text;

        for (int i = 0; i < phraseToGuess.Length; i++)
        {
            if (dna.phrase[i] == phraseToGuess[i])
            {
                fitness++;
            }
        }
    }
}