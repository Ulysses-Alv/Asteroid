using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInputMap playerInputMap;
        private void Awake()
        {
            playerInputMap = new PlayerInputMap();

            playerInputMap.Player.Enable();
            playerInputMap.Player.Shoot.started += ShootStarted;
            playerInputMap.Player.Shoot.canceled += ShootCanceled;
        }

        private void ShootCanceled(InputAction.CallbackContext context)
        {
            if (GameStateManager.instance.actualGameState.Value == GameStates.Lose) return;

            BulletSpawner.instance.StopShooting();
        }

        private void ShootStarted(InputAction.CallbackContext context)
        {
            if (GameStateManager.instance.actualGameState.Value == GameStates.Lose) return;

            BulletSpawner.instance.StartShooting();
        }

        private void Update()
        {
            if (GameStateManager.instance.actualGameState.Value == GameStates.Lose) return;

            Vector2 input = playerInputMap.Player.Movement.ReadValue<Vector2>();
            
            MovePlayer(input);
        }
        private void MovePlayer(Vector2 input)
        {
            PlayerMovementController.instance.Move(input);
        }
    }

}


