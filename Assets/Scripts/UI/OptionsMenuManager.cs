using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject canvasOptionMenu;

    [SerializeField] private Button Salir;

    private void Start()
    {
        Salir.onClick.AddListener(ExitButton);
    }

    private void ExitButton()
    {
        CloseMenu();
        GameStateManager.AlternatePause();
    }

    public void OpenOptionsMenu()
    {
        canvasOptionMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        canvasOptionMenu.SetActive(false);
    }
}