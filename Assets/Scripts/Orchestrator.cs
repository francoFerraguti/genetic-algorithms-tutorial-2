using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    void Awake()
    {
        PhraseHelper.Init();

        UIManager.Init();
    }
}
