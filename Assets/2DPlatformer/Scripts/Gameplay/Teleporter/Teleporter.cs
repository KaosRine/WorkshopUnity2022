namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.UI;

    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private TeleporterHUDMenu _teleporterMenu = null;

        private Vector3 _teleporterDestination;

        public Vector3 TeleportDestination => _teleporterDestination;

        public void TeleportToDestination(Collider destination)
        {
            var player = LevelReferences.Instance.Player;

            player.transform.position = destination.transform.position;
        }

        public void SetTeleporter()
        {
            _teleporterMenu.GetTeleporter(this);
        }

        public void GetDestination(Collider destination)
        {
            _teleporterDestination = destination.transform.position;
        }
    }
}