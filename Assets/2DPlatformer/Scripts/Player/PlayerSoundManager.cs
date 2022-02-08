namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerSoundManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource = null;

        [SerializeField]
        private AudioClip _jumpSound = null;

        [SerializeField]
        private AudioClip[] _hitSounds = null;

        private CubeController _cubeController = null;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetCubeController(out _cubeController);
        }

        private void OnEnable()
        {
            _cubeController.StateChanged -= CubeControllerOnStateChanged;
            _cubeController.StateChanged += CubeControllerOnStateChanged;
        }

        private void OnDisable()
        {
            _cubeController.StateChanged -= CubeControllerOnStateChanged;
        }

        private void CubeControllerOnStateChanged(CubeController cubeController, CubeController.CubeControllerEventArgs args)
        {
            switch (args.currentState)
            {
                case CubeController.State.None:
                    break;
                case CubeController.State.Grounded:
                    break;
                case CubeController.State.Falling:
                    break;
                case CubeController.State.Bumping:
                    break;
                case CubeController.State.StartJump:
                    {
                        _audioSource.clip = _jumpSound;
                        _audioSource.Play();
                    }
                    break;
                case CubeController.State.Jumping:
                    break;
                case CubeController.State.EndJump:
                    break;
                case CubeController.State.WallGrab:
                    break;
                case CubeController.State.WallJump:
                    break;
                case CubeController.State.Dashing:
                    break;
                case CubeController.State.DamageTaken:
                    {
                        var sound = _hitSounds[Random.Range(0, _hitSounds.Length)];
                        _audioSource.clip = sound;
                        _audioSource.Play();
                    }
                    break;
                case CubeController.State.Everything:
                    break;
                default:
                    break;
            }
        }
    }
}