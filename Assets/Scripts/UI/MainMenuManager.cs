using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button Jugar, Opciones, Salir;

    [SerializeField] private OptionsMenuManager optionsMenuManager;

    private void Start()
    {
        Jugar.onClick.AddListener(PlayGame);
        Opciones.onClick.AddListener(OpenOptionsMenu);
        Salir.onClick.AddListener(ExitApp);
    }

    private void ExitApp()
    {
        Application.Quit();
    }

    private void OpenOptionsMenu()
    {
        optionsMenuManager.OpenOptionsMenu();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
        GameStateManager.StartPlaying();
    }
}
