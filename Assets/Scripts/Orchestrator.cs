using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    void Awake()
    {
        PhraseHelper.Init();
        ReproductionHelper.Init();
        MutationHelper.Init();
        UIManager.Init();
        PopulationManager.Init();
    }

    void Start()
    {
        PopulationManager.AssignPopulation();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PopulationManager.AdvanceGeneration();
        }
    }
}
