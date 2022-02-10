namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.EventSystems;

    public class PlayerMenuController : MonoBehaviour
    {
        [SerializeField]
        private EventSystem _eventSystem = null;

        [SerializeField]
        private GameObject _pauseMenuFirstSelected = null;

        [SerializeField]
        private GameObject _peltInventoryFirstSelected = null;

        private PlayerController _playerController = null;

        private void OnEnable()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _playerController);

            _playerController.PauseMenuPerformed -= PlayerControllerOnPauseMenuPerformed;
            _playerController.PeltInventoryPerformed -= PlayerControllerOnPeltInventoryPerformed;

            _playerController.PauseMenuPerformed += PlayerControllerOnPauseMenuPerformed;
            _playerController.PeltInventoryPerformed += PlayerControllerOnPeltInventoryPerformed;

            _playerController.MapPerformed -= PlayerControllerOnMapPerformed;
            _playerController.MapPerformed += PlayerControllerOnMapPerformed;
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
                _eventSystem.SetSelectedGameObject(_pauseMenuFirstSelected);
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
                _eventSystem.SetSelectedGameObject(_peltInventoryFirstSelected);
                LevelReferences.Instance.UIManager.ShowPeltInventoryMenu(true);
            }
        }

        private void PlayerControllerOnMapPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Map map = LevelReferences.Instance.UIManager.Map;

            if (map.gameObject.activeSelf == true)
            {
                LevelReferences.Instance.UIManager.ShowMap(false);
            }
            else
            {
                LevelReferences.Instance.UIManager.ShowMap(true);
            }
        }
    }
}