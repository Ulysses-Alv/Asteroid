using ObjectPoolingPattern;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawnLogic : EnemySpawnLogic
{
    [SerializeField] private float minRadius, maxRadius, maxDistance;
    public override void SpawnEnemy(int Amount, GameObject prefab)
    {
        for (int i = 0; i < Amount; i++)
        {
            GameObject go = ObjectPooling.GetObject(prefab);

            go.transform.position = GenerateRandomPoint(transform.position);
            go.GetComponent<Asteroid>().InitializeAsteroid(maxDistance);
        }
    }
    public Vector2 GenerateRandomPoint(Vector2 center)
    {
        /*
         Esta parte fue generada con GPT, 
        ya que no se me ocurria una manera practica de llevar a cabo el spawn aleatorio.
         */
        float angle = Random.Range(0f, 2f * Mathf.PI);

        float magnitude = Random.Range(minRadius, maxRadius);

        float x = center.x + magnitude * Mathf.Cos(angle);
        float y = center.y + magnitude * Mathf.Sin(angle);

        return new Vector2(x, y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
    

}
