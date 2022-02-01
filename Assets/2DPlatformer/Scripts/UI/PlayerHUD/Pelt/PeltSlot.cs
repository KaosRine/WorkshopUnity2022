namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;

    public class PeltSlot : MonoBehaviour
    {
        [SerializeField]
        private Pelt _peltAssigned = null;

        public Pelt PeltAssigned => _peltAssigned;

        public void AssignSlot(Pelt pelt)
        {
            _peltAssigned = pelt;
        }
    }
}