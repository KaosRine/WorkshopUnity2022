namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using GSGD2.Player;

    public class PeltInventoryMenu : AMenu
    {
        [SerializeField]
        private Image _wolfIcon = null;

        [SerializeField]
        private Image _squirrelIcon = null;

        [SerializeField]
        private PeltSlot[] _equipSlots;

        public Image WolfIcon => _wolfIcon;
        public Image SquirrelIcon => _squirrelIcon;
        public PeltSlot[] EquipSlots => _equipSlots;

        protected override void Awake()
        {
            _wolfIcon.enabled = false;
            _squirrelIcon.enabled = false;
        }

    }
}