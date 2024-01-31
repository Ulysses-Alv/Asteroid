using UnityEngine;
using UniRx;
using ObjectPoolingPattern;
public class EnemiesSpawner : MonoBehaviour, ISpawnObject
{
    [SerializeField] private AsteroidSpawnConfiguration spawnConfig;

    private SpawnerTimer spawnerTimer;
    private EnemySpawnLogic SpawnLogic; //inyecto la logica de spawn, aquí solo necesitamos uno pero permite la extensibilidad

    private void Awake() 
    {
        spawnerTimer = GetComponent<SpawnerTimer>();
        SpawnLogic = GetComponent<AsteroidSpawnLogic>();
    }
    
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
    
#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnObjects();
        }
    }
#endif
}
