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
        private float _timeBeforeDestroy = 1f;

        private Timer _timer = new Timer();

        [SerializeField]

        private void Awake()
        {
            _timer.ForceFinishState();
        }

        private void OnEnable()
        {
            _timer.StateChanged -= TimeBeforeDestroyOnStateChanged;
            _timer.StateChanged += TimeBeforeDestroyOnStateChanged;
        }


        private void OnDisable()
        {
            _timer.StateChanged -= TimeBeforeDestroyOnStateChanged;
        }

        private void Update()
        {
            if (_timer.IsRunning == true)
            {
                _timer.Update();
            }
        }

        public void BreakablePlatformOnEnter(PhysicsTriggerEvent triggerEvent, Collider other)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                _timer.Start(_timeBeforeDestroy);
            }
        }

        public void BreakablePlatformOnExit(PhysicsTriggerEvent triggerEvent, Collider other)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                _timer.Stop();
            }
        }

        private void TimeBeforeDestroyOnStateChanged(Timer timer, Timer.State state)
        {
            if (state == Timer.State.Finished)
            {
                Destroy(this.gameObject);
            }
        }
    }
}