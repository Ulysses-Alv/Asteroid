using ObjectPoolingPattern;
using System;
using UnityEngine;
using UniRx;
public class BulletSpawner : MonoBehaviour, ISpawnObject
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform target;

    Action spawnBullets;

    public static BulletSpawner instance;

    private float timer = 0;
    private float timeBetweenSpawn = 0.1f;

    private Rigidbody2D rb => GetComponentInParent<Rigidbody2D>();

    #region SetInstance
    private void Awake()
    {
        SetInstance();
    }

    private void SetInstance()
    {
        if (instance == null) { instance = this; }
    }
    #endregion

    private void Start()
    {
        ObjectPooling.PreLoad(bulletPrefab, 20);
        GameStateManager.actualGameState.Subscribe(StopShooting);
    }

    private void StopShooting(GameStates states)
    {
        if(states != GameStates.Playing)
        {
            StopShooting();
        }
    }

    public void SpawnObjects()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawn)
        {
            timer -= timeBetweenSpawn;
            
            GameObject bullet = ObjectPooling.GetObject(bulletPrefab);
            bullet.GetComponent<Bullet>().ShootBullet(transform.position, target, rb.velocity);
            ShootEffect.Instance.PlayShootSound();
        }
    }
    private void Update()
    {
        spawnBullets?.Invoke();
    }
    public void StartShooting()
    {
        spawnBullets = SpawnObjects;
    }
    public void StopShooting()
    {
        spawnBullets = null;
    }
}
