using UniRx;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance { get; private set; }
    public ReactiveProperty<GameStates> actualGameState { get; private set; }

    private void Awake()
    {
        actualGameState = new ReactiveProperty<GameStates>(initialValue: GameStates.Menu);
        DontDestroyOnLoad(gameObject);
        SetInstance();
    }

    private void SetInstance()
    {
        if (instance != null && instance != this) 
            Destroy(instance);

        instance = this;
    }

    public void EndGame()
    {
        actualGameState.Value = GameStates.Lose;
    }
}

public enum GameStates
{
    Menu, Paused, Playing, Lose
}
