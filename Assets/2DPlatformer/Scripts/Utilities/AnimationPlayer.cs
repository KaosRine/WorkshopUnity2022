namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator = null;

        public void PlayEnterTrigger()
        {
            _animator.SetTrigger("EnterTP");
            Debug.Log("Enter");
        }

        public void PlayExitTrigger()
        {
            _animator.SetTrigger("ExitTP");
            Debug.Log("Exit");
        }
    }
}