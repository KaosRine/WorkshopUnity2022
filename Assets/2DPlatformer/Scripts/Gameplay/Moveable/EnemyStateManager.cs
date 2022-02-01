namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyStateManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _enemyParts;

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