namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class EnemyStateManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _enemyParts;

        [SerializeField]
        private DamageDealer _damageDealer = null;

        private PlayerDamageable _playerDamageable = null;

        public enum EnemyState
        {
            Patrolling,
            Chasing,
            Dead
        }

        private EnemyState _currentState = 0;

        public EnemyState CurrentState => _currentState;

        public delegate void EnemyStateManagerEvent(EnemyStateManager sender, EnemyState state);
        public event EnemyStateManagerEvent StateChanged = null;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out _playerDamageable);
        }

        public void ChangeState(EnemyState newState)
        {
            _currentState = newState;

            switch (_currentState)
            {
                case EnemyState.Patrolling:
                    break;
                case EnemyState.Chasing:
                    break;
                case EnemyState.Dead:
                    {
                        DoKillEnemy();
                    }
                    break;
                default:
                    break;
            }
            StateChanged?.Invoke(this, _currentState);
        }

        public void ChangeStateToDeath()
        {
            ChangeState(EnemyState.Dead);
        }

        public void DoKillEnemy()
        {
            if (_enemyParts != null)
            {
                foreach (var part in _enemyParts)
                {
                    part.SetActive(false);
                }

            }

            _damageDealer.RemoveFromDamageableInRange(_playerDamageable);
        }

        public void DoReviveEnemy()
        {
            if (_enemyParts != null)
            {
                foreach (var part in _enemyParts)
                {
                    part.SetActive(true);
                }
            }
        }
    }
}