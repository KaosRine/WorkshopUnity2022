namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    public class PeltInventoryManager : MonoBehaviour
    {
        private PeltInventoryMenu _peltInventoryMenu = null;

        private PeltManager _peltManager = null;

        private void OnEnable()
        {
            _peltInventoryMenu = LevelReferences.Instance.UIManager.PeltInventoryMenu;
            LevelReferences.Instance.PlayerReferences.TryGetPeltManager(out _peltManager);
        }

        public void EquipPelt(Sprite image)
        {
            PeltSlot[] slots = _peltInventoryMenu.EquipSlots;
            foreach (var slot in slots)
            {
                if (slot.PeltAssigned == null)
                {
                    //slot.sprite = image;
                    //slot.color = new Color(255, 255, 255, 1);
                    break;
                }
            }

        }

        public void UnequipPelt(Pelt pelt, Pelt.PeltType peltType)
        {
            PeltSlot[] slots = _peltInventoryMenu.EquipSlots;
            foreach (var slot in slots)
            {
                if (slot.PeltAssigned != null && pelt.GetPeltType == peltType)
                {
                    //slot.sprite = null;
                    //slot.color = new Color(255, 255, 255, 0);
                    break;
                }
            }
        }
    }
}