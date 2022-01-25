namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PeltInventory : MonoBehaviour
    {
        [SerializeField]
        private List<Pelt> _pelts;

        public void AddPelt(Pelt newPelt)
        {
            _pelts.Add(newPelt);
        }

        public void RemovePelt(Pelt removePelt)
        {
            _pelts.Remove(removePelt);
        }
    }
}