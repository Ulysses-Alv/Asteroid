using ObjectPoolingPattern;
using UnityEngine;

public class SetUp
    : MonoBehaviour
{
    private void Awake()
    {
        GameStateManager.InitializeGame();
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        ObjectPooling.ClearPools();
    }
}
