namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using GSGD2.UI;
    using GSGD2.Player;
    using UnityEngine.EventSystems;

    public class PeltInventory : AMenu
    {
        [SerializeField]
        private Button[] _buttons = null;

        [SerializeField]
        private int _maxSlotNumber = 2;

        private PeltManager _peltManager = null;

        public delegate void PeltInventoryEvent(PeltInventory sender, Pelt pelt);
        public event PeltInventoryEvent OnEquipPelt = null;
        public event PeltInventoryEvent OnUnequipPelt = null;

        protected override void Awake()
        {
            LevelReferences.Instance.PlayerReferences.TryGetPeltManager(out _peltManager);

            foreach (var button in _buttons)
            {
                button.interactable = false;
            }
        }

        public void AddPelt(Pelt newPelt)
        {
            switch (newPelt.GetPeltType)
            {
                case Pelt.PeltType.None:
                    break;
                case Pelt.PeltType.Wolf:
                    {
                        foreach (var button in _buttons)
                        {
                            if (button.GetComponent<WolfButton>() == true)
                            {
                                button.interactable = true;
                                break;
                            }
                        }
                    }
                    break;
                case Pelt.PeltType.Squirrel:
                    {
                        foreach (var button in _buttons)
                        {
                            if (button.GetComponent<SquirrelButton>() == true)
                            {
                                button.interactable = true;
                                break;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void EquipPelt(Pelt pelt)
        {
            if (_peltManager.EquippedPelts.Contains(pelt) == false && _peltManager.EquippedPelts.Count <= _maxSlotNumber)
            {
                _peltManager.EquippedPelts.Add(pelt);
                _peltManager.SetCurrentPelt(pelt);
                pelt.Apply();
                OnEquipPelt?.Invoke(this, pelt);
            }
            else
            {
                if (_peltManager.EquippedPelts.Count >= 2)
                {
                    _peltManager.SwitchPelt();
                    _peltManager.EquippedPelts.Remove(pelt);
                    //_peltManager.SetCurrentPelt(_peltManager.EquippedPelts[0]);
                    _peltManager.EquippedPelts[0].Apply();
                    OnEquipPelt?.Invoke(this, _peltManager.EquippedPelts[0]);
                    OnUnequipPelt?.Invoke(this, pelt);
                }
                else if (_peltManager.EquippedPelts.Count <= 1)
                {
                    pelt.ResetMovementAbilities();
                    _peltManager.EquippedPelts.Remove(pelt);
                    _peltManager.SetCurrentPelt(null);
                    _peltManager.SetPeltMeshes(true, false, false);
                    OnUnequipPelt?.Invoke(this, pelt);
                }
            }
        }
    }
}