using UnityEngine;
using UniRx;
using ObjectPoolingPattern;
public class EnemiesSpawner : MonoBehaviour, ISpawnObject
{
    [SerializeField] private AsteroidSpawnConfiguration spawnConfig;

    private SpawnerTimer spawnerTimer => GetComponent<SpawnerTimer>();
    private EnemySpawnLogic SpawnLogic => GetComponent<AsteroidSpawnLogic>(); //inyecto la logica de spawn, aquí solo necesitamos uno pero permite la extensibilidad

    private void Start()
    {
        spawnerTimer.timeBetweenSpawn = spawnConfig.timeBetweenSpawn;

        spawnerTimer.OnTrigger.Subscribe(_ => SpawnObjects()).AddTo(this);

        ObjectPooling.PreLoad(spawnConfig.prefab, spawnConfig.preloadAmount);
    }

    public void SpawnObjects()
    {
        SpawnLogic.SpawnEnemy(spawnConfig.spawnCount, spawnConfig.prefab);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnObjects();
        }

#endif
    }
}
