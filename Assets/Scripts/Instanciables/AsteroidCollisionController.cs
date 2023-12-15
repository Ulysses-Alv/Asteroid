using System;
using UnityEngine;

public class AsteroidCollisionController : MonoBehaviour, IDamageable
{
    private float maxHP;
    private float currentHealth;

    [SerializeField] private int damagePerBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.tag == "Bullet")) return;

        ReceiveDamage();

        BulletRecicler.instance.RecicleGO(collision.gameObject);
    }
    public void ReceiveDamage()
    {
        currentHealth -= damagePerBullet;

        if (currentHealth > 0) return;

        ScoreManager.instance.AddScore(maxHP);
        EnemyRecicler.instance.RecicleGO(gameObject);
    }

    public void SetHealth(float health)
    {
        maxHP = health;
        currentHealth = health;
    }
}

