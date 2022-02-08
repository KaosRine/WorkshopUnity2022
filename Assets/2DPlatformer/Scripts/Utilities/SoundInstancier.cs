namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SoundInstancier : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource = null;

        [SerializeField]
        private AudioClip[] _audioClips;

        public void PlayRandomSound()
        {
            AudioClip sound = _audioClips[Random.Range(0, _audioClips.Length)];
            _audioSource.clip = sound;
            _audioSource.Play();
        }
    }
}