namespace GSGD2.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Rendering.PostProcessing;
    using GSGD2.Gameplay;

    public class PostProcessManager : MonoBehaviour
    {
        [SerializeField]
        private PostProcessVolume _postProcessVolume = null;

        [SerializeField]
        private PostProcessProfile _postProcessProfile = null;

        public void ChangePostProcessProfile(PhysicsTriggerEvent physicsEvent, Collider other)
        {
            _postProcessVolume.profile = _postProcessProfile;
        }
    }
}