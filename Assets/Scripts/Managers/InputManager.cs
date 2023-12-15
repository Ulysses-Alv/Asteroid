using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInputMap playerInputMap;

        private bool isPlaying => GameStateManager.IsPlaying();
        private void Awake()
        {
            playerInputMap = new PlayerInputMap();

            playerInputMap.Player.Enable();

            playerInputMap.Player.PauseGame.performed += PauseGame;
            playerInputMap.Player.Shoot.started += ShootStarted;
            playerInputMap.Player.Shoot.canceled += ShootCanceled;
        }

        #region Movement

        private void MovePlayer(Vector2 input)
        {
            PlayerMovementController.instance.Move(input);
        }

        private void Update()
        {
            if (!isPlaying) return;

            Vector2 input = playerInputMap.Player.Movement.ReadValue<Vector2>();
            MovePlayer(input);
        }

        #endregion

        #region Shoot
        private void ShootCanceled(InputAction.CallbackContext context)
        {
            if (!isPlaying) return;

            BulletSpawner.instance.StopShooting();
        }

        private void ShootStarted(InputAction.CallbackContext context)
        {
            if (!isPlaying) return;

            BulletSpawner.instance.StartShooting();
        }
        #endregion

        #region Pause
        private void PauseGame(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                print("hola");
                GameStateManager.AlternatePause();
            }
        }
        #endregion
    }

}


