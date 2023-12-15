using UnityEngine;
using UniRx;
using System;
using System.Collections;

public class SpawnerTimer : MonoBehaviour
{
    [HideInInspector] public float timeBetweenSpawn;

    private float timer;
    private float timeToFirstSpawn = 1f;

    private readonly Subject<Unit> triggerSubject = new Subject<Unit>();
    public IObservable<Unit> OnTrigger => triggerSubject;

    private Action timerAction;

    private void Start()
    {
        GameStateManager.actualGameState.Subscribe(AlternateTimer);
        StartCoroutine(StartTimer());
    }
    private void Update()
    {
        timerAction?.Invoke();
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToFirstSpawn);
        timerAction = Timer;
    }

    private void AlternateTimer(GameStates gameState)
    {
        switch (gameState)
        {
            case GameStates.Playing:
                timerAction = Timer;
                break;

            case GameStates.Paused:
                timerAction = null;
                break;

            default:
                timerAction = null;
                break;
        }
    }

    private void Timer()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawn)
        {
            timer -= timeBetweenSpawn;
            triggerSubject.OnNext(Unit.Default);
        }
    }
}