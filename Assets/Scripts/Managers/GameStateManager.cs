using UniRx;
using UnityEngine;

public static class GameStateManager
{
    //El uso de UniRx para levar a cabo el patron observer es meramente personal.
    //Considero las propiedades reactivas mas legibles que los eventos de unity.
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
