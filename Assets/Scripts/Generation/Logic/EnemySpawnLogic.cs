using System;
using UnityEngine;

public abstract class EnemySpawnLogic : MonoBehaviour
{
    public abstract void SpawnEnemy(int Amount, GameObject prefab);
}