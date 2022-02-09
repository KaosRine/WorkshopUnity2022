namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;

    public class SuperCubeAnimator : MonoBehaviour
    {
        [SerializeField]
        private PlayerReferences _playerReferences = null;

        [SerializeField]
        private float _endJumpDownwardSpeedThresholdWhenGrounded = 5f;

        //Runtime
        private CubeController _cubeController = null;
        private Animator _animator = null;
        private Rigidbody _rigidbody = null;
        private DisplacementEstimationUpdater _displacementEstimationUpdater = null;
        private PlayerController _playerController = null;
        private ExampleGlider _glider = null;

        private void Awake()
        {
            _playerReferences.TryGetCubeController(out _cubeController);
            _playerReferences.TryGetAnimator(out _animator);
            _playerReferences.TryGetRigidbody(out _rigidbody);
            _playerReferences.TryGetDisplacementEstimationUpdater(out _displacementEstimationUpdater);
            _playerReferences.TryGetPlayerController(out _playerController);
            _glider = GetComponent<ExampleGlider>();
        }

        private void OnEnable()
        {
            _cubeController.StateChanged -= OnCubeControllerStateChanged;
            _cubeController.StateChanged += OnCubeControllerStateChanged;

            _playerController.MeleeAttackPerformed -= PlayerControllerOnMeleeAttackPerformed;
            _playerController.MeleeAttackPerformed += PlayerControllerOnMeleeAttackPerformed;
        }


        private void OnDisable()
        {
            _cubeController.StateChanged -= OnCubeControllerStateChanged;
            _playerController.MeleeAttackPerformed -= PlayerControllerOnMeleeAttackPerformed;
        }

        private void OnCubeControllerStateChanged(CubeController cubeController, CubeController.CubeControllerEventArgs args)
        {
            //Debug.Log("SuperCubeAnimator State Changed");

            switch (args.currentState)
            {
                case CubeController.State.None:
                    break;
                case CubeController.State.Grounded:
                    {
                        var downwardVelocityBelowThreshold = Vector3.Dot(_displacementEstimationUpdater.Velocity, -transform.up) > _endJumpDownwardSpeedThresholdWhenGrounded;
                        if (downwardVelocityBelowThreshold == true)
                        {
                            //_animator.SetTrigger("EndJump");
                        }
                        _animator.SetBool("Falling", false);
                    }
                    break;
                case CubeController.State.Falling:
                    {
                        _animator.SetBool("Falling", true);
                    }
                    break;
                case CubeController.State.Bumping:
                    break;
                case CubeController.State.StartJump:
                    {
                        _animator.SetTrigger("Jumping");
                    }
                    break;
                case CubeController.State.Jumping:
                    break;
                case CubeController.State.EndJump:
                    break;
                case CubeController.State.WallGrab:
                    {
                        _animator.SetBool("WallGrab", true);
                    }
                    break;
                case CubeController.State.WallJump:
                    {
                        _animator.SetBool("WallGrab", false);
                        //_animator.SetTrigger("WallJump");
                    }
                    break;
                case CubeController.State.Dashing:
                    {
                        _animator.SetTrigger("Dash");
                    }
                    break;
                case CubeController.State.DamageTaken:
                    break;
                case CubeController.State.Everything:
                    break;
                default:
                    break;
            }
        }

        private void PlayerControllerOnMeleeAttackPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            _animator.SetTrigger("MeleeAttack");
        }

        private void Update()
        {
            float value = Mathf.Abs(_rigidbody.velocity.z);
            _animator.SetFloat("IdleRunBlend", value);

            if (_glider.IsGliding == true)
            {
                _animator.SetBool("Glide", true);
            }
            else
            {
                _animator.SetBool("Glide", false);
            }
        }
    }
}