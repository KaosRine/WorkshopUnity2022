namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.UI;

    public class PeltInventory : MonoBehaviour
    {
        [SerializeField]
        private List<Pelt> _pelts;

        private PeltInventoryMenu _peltInventoryMenu = null;

        private void OnEnable()
        {
            _peltInventoryMenu = LevelReferences.Instance.UIManager.PeltInventoryMenu;
        }

        public void AddPelt(Pelt newPelt)
        {
            _pelts.Add(newPelt);

            switch (newPelt.GetPeltType)
            {
                case Pelt.PeltType.None:
                    break;
                case Pelt.PeltType.Wolf:
                    {
                        _peltInventoryMenu.WolfIcon.enabled = true;
                    }
                    break;
                case Pelt.PeltType.Squirrel:
                    {
                        _peltInventoryMenu.SquirrelIcon.enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        public void RemovePelt(Pelt removePelt)
        {
            _pelts.Remove(removePelt);
        }
        
        /*private void AddToInventory()
        {

            switch (_pelt)
            {
                case PeltType.None:
                    break;
                case PeltType.Wolf:
                    {
                        _peltInventory.AddPelt(this);
                        _peltInventoryMenu.WolfIcon.enabled = true;
                    }
                    break;
                case PeltType.Squirrel:
                    {
                        _peltInventory.AddPelt(this);
                        _peltInventoryMenu.SquirrelIcon.enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }*/

    }
}