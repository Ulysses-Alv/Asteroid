using UnityEngine;
using UniRx;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private GameObject canvasLoseGame;

    void Start()
    {
        GameStateManager.actualGameState.Subscribe(Lose);
    }

    private void Lose(GameStates states)
    {
        if (states != GameStates.Lose) return;
        
        DeathEffect.Instance.PlayDeath();

        canvasLoseGame.SetActive(true);
    }
}
