namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.UI;

    public class PeltManager : MonoBehaviour
    {
        [SerializeField]
        private PeltInventoryManager _peltInventoryManager = null;

        [SerializeField]
        private List<Pelt> _equippedPelts = new List<Pelt>();

        private Pelt _currentPelt = null;

        private PlayerController _playerController = null;
        private PeltInventoryMenu _peltInventoryMenu = null;

        public Pelt CurrentPelt => _currentPelt;

        private void OnEnable()
        {
            _peltInventoryMenu = LevelReferences.Instance.UIManager.PeltInventoryMenu;
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _playerController);

            _playerController.SwitchPeltPerformed -= PlayerControllerOnSwitchPeltPerformed;
            _playerController.SwitchPeltPerformed += PlayerControllerOnSwitchPeltPerformed;
        }

        private void OnDisable()
        {
            _playerController.SwitchPeltPerformed -= PlayerControllerOnSwitchPeltPerformed;
        }

        public void EquipPelt(Pelt equippedPelt)
        {
            if (IsPeltEquipped(equippedPelt) == false)
            {
                _equippedPelts.Add(equippedPelt);

                switch (equippedPelt.GetPeltType)
                {
                    case Pelt.PeltType.None:
                        break;
                    case Pelt.PeltType.Wolf:
                        {
                            _peltInventoryManager.EquipPelt(_peltInventoryMenu.WolfIcon.sprite);
                        }
                        break;
                    case Pelt.PeltType.Squirrel:
                        {
                            _peltInventoryManager.EquipPelt(_peltInventoryMenu.SquirrelIcon.sprite);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _equippedPelts.Remove(equippedPelt);

                switch (equippedPelt.GetPeltType)
                {
                    case Pelt.PeltType.None:
                        break;
                    case Pelt.PeltType.Wolf:
                        {
                            _peltInventoryManager.UnequipPelt(equippedPelt, Pelt.PeltType.Wolf);
                        }
                        break;
                    case Pelt.PeltType.Squirrel:
                        {
                            _peltInventoryManager.UnequipPelt(equippedPelt, Pelt.PeltType.Squirrel);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private bool IsPeltEquipped(Pelt pelt)
        {
            return _equippedPelts.Contains(pelt);
        }

        private void PlayerControllerOnSwitchPeltPerformed(PlayerController sender, UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (_equippedPelts.Count == 2)
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
            }
            Debug.Log(_currentPelt);
        }
    }
}