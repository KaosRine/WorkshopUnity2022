namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SoundInstancier : MonoBehaviour
    {
        [SerializeField]
        private AudioSource[] _audioSources;

        public void PlaySound(int index)
        {
            _audioSources[index].Play();
        }

        public void PlayRandomSound()
        {
            int random = Random.Range(0, _audioSources.Length);
            _audioSources[random].Play();
        }
    }
}