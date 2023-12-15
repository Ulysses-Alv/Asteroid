using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;

    [SerializeField] private Button Continuar, Opciones, Salir;

    [SerializeField] private OptionsMenuManager optionsMenuManager;

    private void Start()
    {
        GameStateManager.actualGameState.Subscribe(AlternateMenu);
        Continuar.onClick.AddListener(KeepPlaying);
        Opciones.onClick.AddListener(OpenOptionsMenu);
        Salir.onClick.AddListener(GoBackMenu);
    }

    private void GoBackMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OpenOptionsMenu()
    {
        optionsMenuManager.OpenOptionsMenu();
    }

    private void KeepPlaying()
    {
        GameStateManager.StartPlaying();
    }

    private void AlternateMenu(GameStates states)
    {
        switch (states)
        {
            case GameStates.Playing:
                CloseMenu();
                break;
            case GameStates.Paused:
                OpenMenu();
                break;
            default:
                break;
        }
    }

    private void OpenMenu()
    {
        menuCanvas.SetActive(true);
    }

    private void CloseMenu()
    {
        menuCanvas.SetActive(false);
        optionsMenuManager.CloseMenu();
    }
}