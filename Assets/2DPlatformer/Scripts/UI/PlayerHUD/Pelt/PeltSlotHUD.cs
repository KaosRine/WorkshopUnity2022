namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.UI;

    public class PeltSlotHUD : MonoBehaviour
    {
        [SerializeField]
        private PeltSlot _slot1 = null;

        [SerializeField]
        private PeltSlot _slot2 = null;

        private PeltInventory _peltInventory = null;
        private PeltManager _peltManager = null;

        private void Awake()
        {
            _peltInventory = LevelReferences.Instance.UIManager.PeltInventory;
            LevelReferences.Instance.PlayerReferences.TryGetPeltManager(out _peltManager);
        }

        private void OnEnable()
        {
            _peltInventory.OnEquipPelt -= PeltInventoryOnEquipPelt;
            _peltInventory.OnEquipPelt += PeltInventoryOnEquipPelt;

            _peltInventory.OnUnequipPelt -= PeltInventoryOnUnequipPelt;
            _peltInventory.OnUnequipPelt += PeltInventoryOnUnequipPelt;

            _peltManager.SwitchPerformed -= PeltManagerOnSwitchPerformed;
            _peltManager.SwitchPerformed += PeltManagerOnSwitchPerformed;
        }


        private void OnDisable()
        {
            _peltInventory.OnEquipPelt -= PeltInventoryOnEquipPelt;
            _peltInventory.OnUnequipPelt -= PeltInventoryOnUnequipPelt;
            _peltManager.SwitchPerformed -= PeltManagerOnSwitchPerformed;
        }

        private void PeltInventoryOnEquipPelt(PeltInventory sender, Pelt pelt)
        {
            if (_slot1.Image.sprite == null)
            {
                //_slot1.Image.sprite = pelt.Icon;
                //_slot1.Image.color = new Color(255, 255, 255, 1);
                _slot1.SetSlotPelt(pelt);
                ShowSlot(_slot1, pelt.Icon);
            }
            else if (_slot1.Image.sprite != null && _slot2.Image.sprite == null)
            {
                //_slot2.Image.sprite = pelt.Icon;
                //_slot2.Image.color = new Color(255, 255, 255, 1);
                _slot2.SetSlotPelt(pelt);
                ShowSlot(_slot2, pelt.Icon);
                _peltManager.SwitchPelt();
            }
            else if (_slot1.Image.sprite != null && _slot2.Image.sprite != null)
            {
                Debug.Log("Cannot equip");
            }
        }
        private void PeltInventoryOnUnequipPelt(PeltInventory sender, Pelt pelt)
        {
            switch (pelt.GetPeltType)
            {
                case Pelt.PeltType.None:
                    break;
                case Pelt.PeltType.Wolf:
                    {
                        if (_slot1.Image.sprite != null && _slot1.Image.sprite.name == "Wolf_Icon")
                        {
                            //_slot1.Image.sprite = null;
                            //_slot1.Image.color = new Color(255, 255, 255, 0);
                            HideSlot(_slot1);
                        }
                        else if (_slot2.Image.sprite != null && _slot2.Image.sprite.name == "Wolf_Icon")
                        {
                            //_slot2.Image.sprite = null;
                            //_slot2.Image.color = new Color(255, 255, 255, 0);
                            HideSlot(_slot2);
                        }
                    }
                    break;
                case Pelt.PeltType.Squirrel:
                    {
                        if (_slot1.Image.sprite != null && _slot1.Image.sprite.name == "Squirrel_Icon")
                        {
                            //_slot1.Image.sprite = null;
                            //_slot1.Image.color = new Color(255, 255, 255, 0);
                            HideSlot(_slot1);
                        }
                        else if (_slot2.Image.sprite != null && _slot2.Image.sprite.name == "Squirrel_Icon")
                        {
                            //_slot2.Image.sprite = null;
                            //_slot2.Image.color = new Color(255, 255, 255, 0);
                            HideSlot(_slot2);
                        }
                    }
                    break;
                default:
                    break;
            }

            if (_slot2.Image.sprite != null)
            {
                _peltManager.SetCurrentPelt(_slot2.Pelt);
                var temp = _slot2;
                ShowSlot(_slot1, temp.Image.sprite);
                HideSlot(_slot2);

                switch (_slot2.Pelt.GetPeltType)
                {
                    case Pelt.PeltType.None:
                        break;
                    case Pelt.PeltType.Wolf:
                        break;
                    case Pelt.PeltType.Squirrel:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _peltManager.SetCurrentPelt(_slot1.Pelt);
                switch (_slot1.Pelt.GetPeltType)
                {
                    case Pelt.PeltType.None:
                        break;
                    case Pelt.PeltType.Wolf:
                        {
                            _peltManager.SetPeltMeshes(false, true, false);
                        }
                        break;
                    case Pelt.PeltType.Squirrel:
                        {
                            _peltManager.SetPeltMeshes(false, false, true);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (_slot1.Image.sprite == null)
            {
                _peltManager.SetCurrentPelt(null);
                _peltManager.SetPeltMeshes(true, false, false);
            }
        }

        private void PeltManagerOnSwitchPerformed(PeltManager peltManager)
        {
            SwapIcons();
        }

        private void ShowSlot(PeltSlot slot, Sprite sprite)
        {
            slot.Image.sprite = sprite;
            slot.Image.color = new Color(255, 255, 255, 1);
        }

        private void HideSlot(PeltSlot slot)
        {
            slot.Image.sprite = null;
            slot.Image.color = new Color(255, 255, 255, 0);
        }

        private void SwapIcons()
        {
            var temp = _slot1.Image.sprite;
            _slot1.Image.sprite = _slot2.Image.sprite;
            _slot2.Image.sprite = temp;
        }
    }
}