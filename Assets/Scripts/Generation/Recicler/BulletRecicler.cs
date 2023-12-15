using ObjectPoolingPattern;
using UnityEngine;

public class BulletRecicler : Recicler
{
    public static BulletRecicler instance;

    [SerializeField] private GameObject prefab;

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


    public override void RecicleGO(GameObject GOToRecicle)
    {
        ObjectPooling.RecicleObject(prefab, GOToRecicle);
    }
}
