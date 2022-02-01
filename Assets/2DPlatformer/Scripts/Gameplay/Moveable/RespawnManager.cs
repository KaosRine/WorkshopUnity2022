namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;

    public class RespawnManager : MonoBehaviour
    {
        [SerializeField]
        private float _timeBeforeRespawn = 5f;

        [SerializeField]
        private Transform _spawnPoint = null;

        private EnemyStateManager _enemyStateManager = null;
        private Timer _timer = new Timer();

        private void Awake()
        {
            _enemyStateManager = GetComponentInParent<EnemyStateManager>();

            _timer.ForceFinishState();
        }

        private void OnEnable()
        {
            _timer.StateChanged -= TimerOnStateChanged;
            _timer.StateChanged += TimerOnStateChanged;

            _enemyStateManager.StateChanged -= EnemyStateManagerOnStateChanged;
            _enemyStateManager.StateChanged += EnemyStateManagerOnStateChanged;
        }

        private void OnDisable()
        {
            _timer.StateChanged -= TimerOnStateChanged;
            _enemyStateManager.StateChanged -= EnemyStateManagerOnStateChanged;
        }

        private void Update()
        {
            if (_timer.IsRunning == true)
            {
                _timer.Update();
            }
        }

        private void EnemyStateManagerOnStateChanged(EnemyStateManager sender, EnemyStateManager.EnemyState state)
        {
            if (state == EnemyStateManager.EnemyState.Dead)
            {
                _timer.Start(_timeBeforeRespawn);
            }
        }

        private void TimerOnStateChanged(Timer timer, Timer.State state)
        {
            if (state == Timer.State.Finished)
            {
                _enemyStateManager.DoReviveEnemy();
                transform.position = _spawnPoint.position;
                _enemyStateManager.ChangeState(EnemyStateManager.EnemyState.Patrolling);
            }
        }
    }
}