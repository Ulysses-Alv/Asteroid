using UnityEngine;

[CreateAssetMenu(menuName = "Config/Asteroid Configuration")]

public class AsteroidSpawnConfiguration : ScriptableObject
{
    [Range(1, 15)]
    public int spawnCount;

    [Range(15, 30)]
    public int preloadAmount;
    
    [Range(3f, 10f)]
    public float timeBetweenSpawn;

    public GameObject prefab;
}

/*
 * Inyectar la configuracion del spawn permite a futuro modificar la complejidad.
 */