using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;

    public static BulletDamage instance;

    private void Awake()
    {
        instance = this;
    }
}
