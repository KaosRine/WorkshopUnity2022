namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class AggressiveEnemy : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1f;

        [SerializeField]
        private float _loseSightDistance = 5f;

        private bool _hasTarget = false;
        private Vector3 _targetPosition;
        private EnemyStateManager _enemyStateManager = null;

        private void Awake()
        {
            _enemyStateManager = GetComponentInParent<EnemyStateManager>();
        }

        public void AggressivePathFollowerOnEnter(PhysicsTriggerEvent physicsEvent, Collider other)
        {
            _enemyStateManager.ChangeState(EnemyStateManager.EnemyState.Chasing);

            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            if (playerController != null)
            {
                _hasTarget = true;
            }
        }

        private void Update()
        {
            if (_enemyStateManager.CurrentState == EnemyStateManager.EnemyState.Chasing)
            {
                TryGetTarget();
                RotateToTarget(_targetPosition);
                DoChaseTarget(_targetPosition);
            }

            if (Vector3.Distance(transform.position, _targetPosition) > _loseSightDistance)
            {
                _hasTarget = false;
                _enemyStateManager.ChangeState(EnemyStateManager.EnemyState.Patrolling);
            }
        }

        private Vector3 TryGetTarget()
        {
            if (_hasTarget == true)
            {
                _targetPosition = LevelReferences.Instance.Player.transform.position;
            }
            return _targetPosition;
        }

        private void RotateToTarget(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        private void DoChaseTarget(Vector3 targetPosition)
        {
            transform.position += (targetPosition - transform.position).normalized * _speed * Time.deltaTime;
        }
    }
}