namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class PlayerMenuController : MonoBehaviour
    {
        private PlayerController _playerController = null;

        private void OnEnable()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _playerController);

            _playerController.PauseMenuPerformed -= PlayerControllerOnPauseMenuPerformed;
            _playerController.PeltInventoryPerformed -= PlayerControllerOnPeltInventoryPerformed;

            _playerController.PauseMenuPerformed += PlayerControllerOnPauseMenuPerformed;
            _playerController.PeltInventoryPerformed += PlayerControllerOnPeltInventoryPerformed;
        }

        private void OnDisable()
        {
            _playerController.PauseMenuPerformed -= PlayerControllerOnPauseMenuPerformed;
            _playerController.PeltInventoryPerformed -= PlayerControllerOnPeltInventoryPerformed;
        }

        private void PlayerControllerOnPauseMenuPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            PauseMenu pauseMenu = LevelReferences.Instance.UIManager.PauseMenu;

            if (pauseMenu.gameObject.activeSelf == true)
            {
                LevelReferences.Instance.UIManager.ShowPauseMenu(false);
            }
            else
            {
                LevelReferences.Instance.UIManager.ShowPauseMenu(true);
            }
        }

        private void PlayerControllerOnPeltInventoryPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            PeltInventory peltInventory = LevelReferences.Instance.UIManager.PeltInventory;

            if (peltInventory.gameObject.activeSelf == true)
            {
                LevelReferences.Instance.UIManager.ShowPeltInventoryMenu(false);
            }
            else
            {
                LevelReferences.Instance.UIManager.ShowPeltInventoryMenu(true);
            }
        }
    }
}