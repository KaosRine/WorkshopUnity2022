namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.UI;

    public class PeltSlot : MonoBehaviour
    {
        [SerializeField]
        private Image _image = null;

        private Pelt _pelt = null;

        public Pelt Pelt => _pelt;
        public Image Image => _image;

        public void SetSlotPelt(Pelt pelt)
        {
            _pelt = pelt;
        }
    }
}