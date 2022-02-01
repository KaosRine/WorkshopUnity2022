namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using GSGD2.Player;
    using UnityEngine.UI;
    using TMPro;

    public class Sign : MonoBehaviour
    {
        [SerializeField]
        private PhysicsTriggerEvent _physicsTriggerEvent = null;

        [SerializeField]
        private Image _imageBox = null;

        [SerializeField]
        private TextMeshProUGUI _text = null;

        private PlayerController _playerController = null;
        private bool _isInRange = false;

        private void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _playerController);
            _imageBox.enabled = false;
            _text.enabled = false;
        }
        private void OnEnable()
        {
            _playerController.InteractPerformed -= PlayerControllerOnInteractPerformed;
            _playerController.InteractPerformed += PlayerControllerOnInteractPerformed;

            _physicsTriggerEvent._onTriggerEnter.RemoveListener(OnPhysicsEventEnter);
            _physicsTriggerEvent._onTriggerEnter.AddListener(OnPhysicsEventEnter);
            _physicsTriggerEvent._onTriggerExit.RemoveListener(OnPhysicsEventExit);
            _physicsTriggerEvent._onTriggerExit.AddListener(OnPhysicsEventExit);
        }

        private void OnDisable()
        {
            _playerController.InteractPerformed -= PlayerControllerOnInteractPerformed;
            _physicsTriggerEvent._onTriggerEnter.RemoveListener(OnPhysicsEventEnter);
        }

        private void OnPhysicsEventEnter(PhysicsTriggerEvent physicsEvent, Collider other)
        {
            _isInRange = true;
        }

        private void OnPhysicsEventExit(PhysicsTriggerEvent physicsEvent, Collider other)
        {
            _isInRange = false;
            _imageBox.enabled = false;
            _text.enabled = false;
        }

        private void PlayerControllerOnInteractPerformed(PlayerController sender, InputAction.CallbackContext obj)
        {
            if (_isInRange == true)
            {
                _imageBox.enabled = true;
                _text.enabled = true;
            }
        }
    }
}