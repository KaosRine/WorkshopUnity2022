namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Gameplay;
    using GSGD2.Player;

    public class TeleporterHUDMenu : AMenu
    {
        private Teleporter _teleporter = null;
        private PlayerControllerDeactivator _playerControllerDeactivator = null;

        public void DoTeleport()
        {
            if (_teleporter != null)
            {
                _teleporter.TeleportToDestination(_teleporter.TeleportDestination);
                SetActive(false);
                LevelReferences.Instance.PlayerReferences.TryGetPlayerControllerDeactivator(out _playerControllerDeactivator);
            }
            else
            {
                Debug.LogError("Null Ref Teleporter");
            }
        }

        public void GetTeleporter(Teleporter teleporter)
        {
            _teleporter = teleporter;
        }
    }
}