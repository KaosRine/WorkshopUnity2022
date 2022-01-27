namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;
    using GSGD2.Player;

    public class BreakablePlatform : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _mesh = null;

        [SerializeField]
        private Collider _collider = null;

        [SerializeField]
        private Collider _trigger = null;

        [SerializeField]
        private float _timeBeforeDestroy = 1f;

        [SerializeField]
        private float _respawnTime = 1f;

        private Timer _destroyTimer = new Timer();
        private Timer _respawnTimer = new Timer();

        [SerializeField]

        private void Awake()
        {
            _destroyTimer.ForceFinishState();
            _respawnTimer.ForceFinishState();
        }

        private void OnEnable()
        {
            _destroyTimer.StateChanged -= DestroyTimerOnStateChanged;
            _respawnTimer.StateChanged -= RespawnTimerOnStateChanged;

            _destroyTimer.StateChanged += DestroyTimerOnStateChanged;
            _respawnTimer.StateChanged += RespawnTimerOnStateChanged;
        }


        private void OnDisable()
        {
            _destroyTimer.StateChanged -= DestroyTimerOnStateChanged;
            _respawnTimer.StateChanged -= RespawnTimerOnStateChanged;
        }

        private void Update()
        {
            if (_destroyTimer.IsRunning == true)
            {
                _destroyTimer.Update();
            }

            if (_respawnTimer.IsRunning == true)
            {
                _respawnTimer.Update();
            }
        }

        public void BreakablePlatformOnEnter(PhysicsTriggerEvent triggerEvent, Collider other)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                _destroyTimer.Start(_timeBeforeDestroy);
            }
        }

        public void BreakablePlatformOnExit(PhysicsTriggerEvent triggerEvent, Collider other)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                _destroyTimer.Stop();
            }
        }

        private void DestroyTimerOnStateChanged(Timer timer, Timer.State state)
        {
            if (state == Timer.State.Finished)
            {
                _mesh.enabled = false;
                _collider.enabled = false;
                _trigger.enabled = false;

                _respawnTimer.Start(_respawnTime);
            }
        }

        private void RespawnTimerOnStateChanged(Timer timer, Timer.State state)
        {
            if (state == Timer.State.Finished)
            {
                _mesh.enabled = true;
                _collider.enabled = true;
                _trigger.enabled = true;
            }
        }
    }
}