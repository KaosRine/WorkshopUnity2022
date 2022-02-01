namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;
    using GSGD2.Player;

    public class DamageMeleeAttack : MonoBehaviour
    {
        [SerializeField]
        private PhysicsTriggerEvent _physicsTriggerEvent = null;

        [SerializeField]
        private Damage _damage = null;

        private PlayerMeleeAttack _playerMeleeAttack = null;
        private Timer _timer = new Timer();

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerMeleeAttack(out _playerMeleeAttack);
            _timer.ForceFinishState();
            _timer.Start(0.1f);
        }

        private void OnEnable()
        {
            _timer.StateChanged -= TimerOnStateChanged;
            _timer.StateChanged += TimerOnStateChanged;

            _physicsTriggerEvent._onTriggerEnter.RemoveListener(OnTriggerEventEnter);
            _physicsTriggerEvent._onTriggerEnter.AddListener(OnTriggerEventEnter);
        }

        private void OnDisable()
        {
            _timer.StateChanged -= TimerOnStateChanged;

            _physicsTriggerEvent._onTriggerEnter.RemoveListener(OnTriggerEventEnter);
        }

        private void Update()
        {
            if (_timer.IsRunning == true)
            {
                _timer.Update();
            }
        }

        private void OnTriggerEventEnter(PhysicsTriggerEvent physicsTriggerEvent, Collider other)
        {
            EnemyDamageable damageable = other.GetComponentInParent<EnemyDamageable>();

            if (damageable != null && other.gameObject.name == "Trigger.Damage")
            {
                Debug.Log("Hit");
                damageable.TakeDamage(_damage);
                Destroy(this.gameObject);
            }
        }

        private void TimerOnStateChanged(Timer timer, Timer.State state)
        {
            if (state == Timer.State.Finished)
            {
                Destroy(this.gameObject);
            }
        }
    }
}