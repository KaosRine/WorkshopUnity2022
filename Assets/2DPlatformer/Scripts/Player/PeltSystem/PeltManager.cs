namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PeltManager : MonoBehaviour
    {
        public enum Pelt
        {
            None,
            Wolf,
            Squirrel
        }

        private Pelt _currentPelt = Pelt.None;

        public Pelt CurrentPelt => _currentPelt;

        public delegate void PeltManagerEvent(PeltManager coatManager, Pelt newPelt);

        public void ChangeCurrentCoat(Pelt newPelt)
        {
            _currentPelt = newPelt;
        }
    }
}