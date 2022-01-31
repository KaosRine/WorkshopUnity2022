namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.UI;
    using GSGD2.Utilities;
    using GSGD2.Player;

    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private TeleporterHUDMenu _teleporterMenu = null;

        private Vector3 _teleporterDestination;
        private Rigidbody _rigidbody = null;
        private PlayerControllerDeactivator _playerControllerDeactivator = null;
        private Timer _timer = new Timer();

        public Vector3 TeleportDestination => _teleporterDestination;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetRigidbody(out _rigidbody);
            LevelReferences.Instance.PlayerReferences.TryGetPlayerControllerDeactivator(out _playerControllerDeactivator);
            _timer.ForceFinishState();
        }

        private void OnEnable()
        {
            _timer.StateChanged -= TimerOnStateChanged;
            _timer.StateChanged += TimerOnStateChanged;
        }

        private void OnDisable()
        {
            _timer.StateChanged -= TimerOnStateChanged;
        }

        private void Update()
        {
            if (_timer.IsRunning == true)
            {
                _timer.Update();
            }
        }

        public void TeleportToDestination(Collider destination)
        {
            var player = LevelReferences.Instance.Player;

            player.transform.position = destination.transform.position;
            _rigidbody.velocity = Vector3.zero;
            _playerControllerDeactivator.DoDeactivatePlayerController();
            _timer.Start(0.2f);
        }

        public void SetTeleporter()
        {
            _teleporterMenu.GetTeleporter(this);
        }

        public void GetDestination(Collider destination)
        {
            _teleporterDestination = destination.transform.position;
        }

        private void TimerOnStateChanged(Timer timer, Timer.State state)
        {
            if (state == Timer.State.Finished)
            {
                _playerControllerDeactivator.DoActivatePlayerController();
            }
        }
    }
}