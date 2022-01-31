namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Gameplay;
    using GSGD2.Utilities;

    public class PlayerMeleeAttack : MonoBehaviour
    {
        [SerializeField]
        private DamageMeleeAttack _meleeAttackCollider = null;

        private PlayerController _playerController = null;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _playerController);
        }

        private void OnEnable()
        {
            _playerController.MeleeAttackPerformed -= PlayerControllerOnMeleeAttackPerformed;

            _playerController.MeleeAttackPerformed += PlayerControllerOnMeleeAttackPerformed;
        }

        private void OnDisable()
        {
            _playerController.MeleeAttackPerformed -= PlayerControllerOnMeleeAttackPerformed;
        }

        private void PlayerControllerOnMeleeAttackPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            DamageMeleeAttack instance = Instantiate<DamageMeleeAttack>(_meleeAttackCollider, transform);

            if (instance != null)
            {
                Destroy(instance.gameObject, 2f);
            }
        }
    }
}