namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.UI;

    public class PeltManager : MonoBehaviour
    {
        [SerializeField]
        private List<Pelt> _equippedPelts = new List<Pelt>();

        [SerializeField]
        private PeltSlotHUD _peltSlotHUD = null;

        private PlayerController _playerController = null;
        private Pelt _currentPelt = null;

        public List<Pelt> EquippedPelts => _equippedPelts;
        public Pelt CurrentPelt => _currentPelt;

        public delegate void PeltManagerEvent(PeltManager peltManager);
        public event PeltManagerEvent SwitchPerformed = null;

        private void OnEnable()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _playerController);

            _playerController.SwitchPeltPerformed -= PlayerControllerOnSwitchPeltPerformed;
            _playerController.SwitchPeltPerformed += PlayerControllerOnSwitchPeltPerformed;
        }

        private void OnDisable()
        {
            _playerController.SwitchPeltPerformed -= PlayerControllerOnSwitchPeltPerformed;
        }

        private void PlayerControllerOnSwitchPeltPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            /*if (_equippedPelts.Count == 2)
            {
                if (_currentPelt == null)
                {
                    _currentPelt = _equippedPelts[0];
                    _currentPelt.Apply();
                }
                else if (_currentPelt == _equippedPelts[0])
                {
                    _currentPelt = _equippedPelts[1];
                    _currentPelt.Apply();
                }
                else if (_currentPelt == _equippedPelts[1])
                {
                    _currentPelt = _equippedPelts[0];
                    _currentPelt.Apply();
                }
            }
            else if (_equippedPelts.Count > 0 && _currentPelt != _equippedPelts[0])
            {
                _currentPelt = _equippedPelts[0];
                _currentPelt.Apply();
            }*/
            Debug.Log(_currentPelt);

            SwitchPelt();
        }

        public void SwitchPelt()
        {
            if (_equippedPelts.Count >= 2)
            {
                var temp = _equippedPelts[0];
                _equippedPelts[0] = _equippedPelts[1];
                _equippedPelts[1] = temp;
                _currentPelt = _equippedPelts[0];
                _currentPelt.Apply();
                SwitchPerformed?.Invoke(this);
            }
        }

        public void SetCurrentPelt(Pelt newPelt)
        {
            _currentPelt = newPelt;
        }
    }
}