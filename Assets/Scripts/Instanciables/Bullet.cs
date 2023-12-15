using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    public void ShootBullet(Vector3 position, Transform target, Vector2 velocity)
    {
        transform.position = position;

        Vector2 destino = target.position - transform.position;

        rb.velocity = velocity + destino * 5f;
        StartCoroutine(ReciclingBullet());
    }
    IEnumerator ReciclingBullet()
    {
        yield return BulletsWaitForSeconds.waitForThreeSeconds;
        BulletRecicler.instance.RecicleGO(gameObject);
    }
}

public static class BulletsWaitForSeconds
{
    public static WaitForSeconds waitForThreeSeconds = new WaitForSeconds(3);
    //Al tener todos los bullets que hacer esto y como lo quise manejar con corrutinas
    //era pertinente utilizar un solo WaitForSeconds y no instanciar uno por cada bala.
}
