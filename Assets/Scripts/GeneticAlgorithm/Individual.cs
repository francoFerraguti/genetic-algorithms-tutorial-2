using UnityEngine;
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

    }
}