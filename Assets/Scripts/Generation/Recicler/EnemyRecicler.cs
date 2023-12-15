using ObjectPoolingPattern;
using UnityEngine;

public class EnemyRecicler : Recicler
{
    [SerializeField] private GameObject prefab;

    public static EnemyRecicler instance {  get; private set; }

    private GameObject[] prefabs;

    private void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
        }
    }

    public override void RecicleGO(GameObject asteroid)
    {
        ObjectPooling.RecicleObject(prefab, asteroid);
    }

    protected void OnTriggerAction(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Asteroid")) return;

        RecicleGO(collision.gameObject);
    }
}