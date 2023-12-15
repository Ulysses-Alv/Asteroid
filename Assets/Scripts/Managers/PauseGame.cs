using UnityEngine;
using UniRx;

public class PauseGame : MonoBehaviour
{
    private void Start()
    {
        GameStateManager.actualGameState.Subscribe(AlternatePause);
    }

    private void AlternatePause(GameStates states)
    {
        switch (states)
        {
            case GameStates.Paused:
                Freeze();
                break;

            default:
                Unfreeze();
                break;
        }
    }

    private void Unfreeze()
    {
        Time.timeScale = 1;
    }

    private void Freeze()
    {
        Time.timeScale = 0f;
    }
}