using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float health;

    [SerializeField] private AnimationCurve scaleCurve;

    private float maxDistance;

    [SerializeField, Range(0f, 1f)]
    private float errorMargin = 0.5f; //para que no vaya tan estrictamente lineal al jugador

    private Vector3 targetPosition => PlayerMovementController.instance.gameObject.transform.position;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    [SerializeField] float speed;
    public void InitializeAsteroid(float maxDistance)
    {
        this.maxDistance = maxDistance;

        SetUpAsteroidSize();
        SetMovement();

        GetComponent<AsteroidCollisionController>().SetHealth(health);
    }

    private void SetMovement()
    {
        Vector3 movement = DistanceToPlayer();
        movement.x *= 1f + Random.Range(-errorMargin, errorMargin);
        movement.y *= 1f + Random.Range(-errorMargin, errorMargin);
        movement *= 0.05f;
        
        rb.velocity = movement * speed;
    }

    private Vector3 DistanceToPlayer()
    {
        Vector3 direction = targetPosition - transform.position;

        return direction;
    }

    private void SetUpAsteroidSize()
    {
        health = Random.Range(1f, 101f);
        transform.localScale = Vector3.one * (scaleCurve.Evaluate(health) / 15);
        rb.mass = scaleCurve.Evaluate(health);
    }

    void Update()
    {
        if (DistanceToPlayer().magnitude >= maxDistance)
        {
            EnemyRecicler.instance.RecicleGO(gameObject);
            //si el jugador se aleja de este objeto, simplemente se recicla para no consumir memoria.
        }
    }
}