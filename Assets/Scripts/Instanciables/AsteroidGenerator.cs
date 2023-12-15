using ObjectPoolingPattern;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;

    private void Awake()
    {
        ObjectPooling.PreLoad(asteroidPrefab, 10);
    }

}

public class Timer : MonoBehaviour
{

}