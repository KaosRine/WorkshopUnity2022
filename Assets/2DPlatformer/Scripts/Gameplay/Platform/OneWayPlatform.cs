namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class OneWayPlatform : MonoBehaviour
    {
        private Collider _platformCollider = null;

        private void Awake()
        {
            _platformCollider = GetComponent<Collider>();
        }

        public void OneWayPlatformOnEnter(PhysicsTriggerEvent triggerEvent, Collider other)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();

            if (playerController != null)
            {
                Physics.IgnoreCollision(_platformCollider, other, true);
            }
        }

        public void OneWayPlatformOnExit(PhysicsTriggerEvent triggerEvent, Collider other)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
                
            if (playerController != null)
            {
                Physics.IgnoreCollision(_platformCollider, other, false);
            }
        }
    }
}