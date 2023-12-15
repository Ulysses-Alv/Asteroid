using UnityEngine;

public class AsteroidCollisionController : MonoBehaviour, IDamageable
{
    private float maxHP;
    private float currentHealth;

    private int damage;
    private void Start()
    {
        damage = BulletDamage.instance.damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.tag == "Bullet")) return;

        ReceiveDamage();
        BulletRecicler.instance.RecicleGO(collision.gameObject);
    }
    public void ReceiveDamage()
    {
        currentHealth -= damage;

        if (currentHealth > 0) return;

        ExplosionEffect.Instance.PlayExplosion();
        ScoreManager.instance.AddScore(maxHP);
        EnemyRecicler.instance.RecicleGO(gameObject);
    }

    public void SetHealth(float health)
    {
        maxHP = health;
        currentHealth = health;
    }

}

public interface IDamageable
{
    public void ReceiveDamage();
}