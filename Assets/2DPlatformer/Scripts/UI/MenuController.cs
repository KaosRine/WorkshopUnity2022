namespace GSGD2.UI
{
    using GSGD2.Gameplay;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using GSGD2.Player;

    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        private bool _doRestrictControls = true;

        private PlayerControllerDeactivator _playerControllerDeactivator = null;

        private void Awake()
        {
            LevelReferences levelReference = LevelReferences.Instance;
            levelReference.PlayerReferences.TryGetPlayerControllerDeactivator(out _playerControllerDeactivator);

            gameObject.SetActive(false);
        }

        public void RestrictControls()
        {
            //gameObject.SetActive(true);

            if (_playerControllerDeactivator && _doRestrictControls == true)
            {
                _playerControllerDeactivator.DoDeactivatePlayerController();
            }
        }

        public void EnableControls()
        {
            //gameObject.SetActive(false);

            if (_playerControllerDeactivator && _doRestrictControls == true)
            {
                _playerControllerDeactivator.DoActivatePlayerController();
            }
        }
    }
}