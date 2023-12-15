using System;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour, IDamageable
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Asteroid")) return;

        EnemyRecicler.instance.RecicleGO(collision.gameObject);

        ReceiveDamage();
    }

    public void ReceiveDamage()
    {
        print("DAÑADO FIN DE JUEGO");
        GameStateManager.instance.EndGame();
    }
}
