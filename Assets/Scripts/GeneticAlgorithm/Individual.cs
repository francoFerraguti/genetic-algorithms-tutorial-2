using UnityEngine;
using UnityEngine.UI;
public class Individual : MonoBehaviour
{

    public int fitness = 0;
    public DNA dna;

    public void Init()
    {
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