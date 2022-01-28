namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class WindZoneElement : MonoBehaviour
    {
        [SerializeField]
        private float _force = 3f;

        private PeltManager _peltManager = null;
        private Rigidbody _rigidbody = null;

        public void WindZoneOnTriggerEnter(PhysicsTriggerEvent physicsEvent, Collider other)
        {
            _peltManager = other.GetComponentInParent<PeltManager>();
            var glider = other.GetComponentInParent<ExampleGlider>();

            if (_peltManager != null && glider.IsGliding == true)
            {
                _rigidbody = other.GetComponentInParent<Rigidbody>();
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(new Vector3(0, _force / 3, 0), ForceMode.Impulse);
            }
        }

        public void WindZoneOnTriggerStay(PhysicsTriggerEvent physicsEvent, Collider other)
        {
            _peltManager = other.GetComponentInParent<PeltManager>();
            var glider = other.GetComponentInParent<ExampleGlider>();

            if (_peltManager != null && glider.IsGliding == true)
            {
                _rigidbody = other.GetComponentInParent<Rigidbody>();
                _rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
                _rigidbody.AddForce(Vector3.up * _force, ForceMode.Acceleration);
                Mathf.Clamp(_rigidbody.velocity.y, 0, 50);
            }
        }
    }
}