using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseGameUI : MonoBehaviour
{
    [SerializeField] private Button VolverAlMenu, Salir;

    private void Start()
    {
        VolverAlMenu.onClick.AddListener(() => SceneManager.LoadScene(0));
        Salir.onClick.AddListener(() => Application.Quit());
    }
}