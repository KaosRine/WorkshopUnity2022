namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyStateManager : MonoBehaviour
    {
        public enum EnemyState
        {
            Patrolling,
            Chasing
        }

        private EnemyState _currentState = 0;

        public EnemyState CurrentState => _currentState;

        public void ChangeState(EnemyState newState)
        {
            _currentState = newState;
        }
    }
}