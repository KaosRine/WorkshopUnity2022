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

        [SerializeField]
        private MeshRenderer _defaultHood = null;

        [SerializeField]
        private MeshRenderer _wolfPelt = null;

        [SerializeField]
        private MeshRenderer _squirrelPelt = null;

        private PlayerController _playerController = null;
        private PeltInventory _peltInventory = null;
        private Pelt _currentPelt = null;

        public List<Pelt> EquippedPelts => _equippedPelts;
        public Pelt CurrentPelt => _currentPelt;

        public delegate void PeltManagerEvent(PeltManager peltManager);
        public event PeltManagerEvent SwitchPerformed = null;

        private void Awake()
        {
            SetPeltMeshes(true, false, false);
        }

        private void OnEnable()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out _playerController);
            _peltInventory = LevelReferences.Instance.UIManager.PeltInventory;

            _playerController.SwitchPeltPerformed -= PlayerControllerOnSwitchPeltPerformed;
            _playerController.SwitchPeltPerformed += PlayerControllerOnSwitchPeltPerformed;

            _peltInventory.OnEquipPelt -= PeltInventoryOnEquipPeltPerformed;
            _peltInventory.OnEquipPelt += PeltInventoryOnEquipPeltPerformed;
            _peltInventory.OnUnequipPelt -= PeltInventoryOnUnequipPeltPerformed;
            _peltInventory.OnUnequipPelt += PeltInventoryOnUnequipPeltPerformed;
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

            SwitchPelt();
            Debug.Log(_currentPelt);
        }

        private void PeltInventoryOnEquipPeltPerformed(PeltInventory sender, Pelt pelt)
        {
            switch (pelt.GetPeltType)
            {
                case Pelt.PeltType.None:
                    {
                        SetPeltMeshes(true, false, false);
                    }
                    break;
                case Pelt.PeltType.Wolf:
                    {
                        SetPeltMeshes(false, true, false);
                    }
                    break;
                case Pelt.PeltType.Squirrel:
                    {
                        SetPeltMeshes(false, false, true);
                    }
                    break;
                default:
                    break;
            }
        }

        private void PeltInventoryOnUnequipPeltPerformed(PeltInventory sender, Pelt pelt)
        {

        }

        public void SwitchPelt()
        {
            if (_equippedPelts.Count >= 2)
            {
                var temp = _equippedPelts[0];
                _equippedPelts[0] = _equippedPelts[1];
                _equippedPelts[1] = temp;
                _currentPelt = _equippedPelts[0];
                SetCurrentPelt(_currentPelt);
                _currentPelt.Apply();
                SwitchPerformed?.Invoke(this);

                switch (_currentPelt.GetPeltType)
                {
                    case Pelt.PeltType.None:
                        {
                            SetPeltMeshes(true, false, false);
                        }
                        break;
                    case Pelt.PeltType.Wolf:
                        {
                            SetPeltMeshes(false, true, false);
                        }
                        break;
                    case Pelt.PeltType.Squirrel:
                        {
                            SetPeltMeshes(false, false, true);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetCurrentPelt(Pelt newPelt)
        {
            _currentPelt = newPelt;

            /*switch (newPelt.GetPeltType)
            {
                case Pelt.PeltType.None:
                    {
                        SetPeltMeshes(true, false, false);
                    }
                    break;
                case Pelt.PeltType.Wolf:
                    {
                        SetPeltMeshes(false, true, false);
                    }
                    break;
                case Pelt.PeltType.Squirrel:
                    {
                        SetPeltMeshes(false, false, true);
                    }
                    break;
                default:
                    break;
            }*/
        }

        public void SetPeltMeshes(bool defaultHood, bool wolfPelt, bool squirrelPelt)
        {
            _defaultHood.enabled = defaultHood;
            _wolfPelt.enabled = wolfPelt;
            _squirrelPelt.enabled = squirrelPelt;
        }
    }
}