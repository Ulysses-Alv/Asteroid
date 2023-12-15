using UniRx;
using UnityEngine;

public static class GameStateManager
{
    public static ReactiveProperty<GameStates> actualGameState { get; private set; }

    public static void EndGame()
    {
        actualGameState.Value = GameStates.Lose;
    }
    public static void AlternatePause()
    {
        switch (actualGameState.Value)
        {
            case GameStates.Playing:
                actualGameState.Value = GameStates.Paused;
                break;
            case GameStates.Paused:
                actualGameState.Value = GameStates.Playing;
                break;
            default:
                break;
        }
        Debug.Log(actualGameState.Value);
    }

    public static bool IsPlaying()
    {
        return actualGameState.Value == GameStates.Playing;
    }

    public static void InitializeGame()
    {
        actualGameState = new ReactiveProperty<GameStates>(GameStates.Menu);
    }

    public static void StartPlaying()
    {
        actualGameState.Value = GameStates.Playing;
    }
}

public enum GameStates
{
    Menu, Paused, Playing, Lose
}
