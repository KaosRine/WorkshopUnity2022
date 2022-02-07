namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class EventSystemController : MonoBehaviour
    {
        [SerializeField]
        private EventSystem _eventSystem = null;

        public void SetSelectedGameObject(GameObject gameObject)
        {
            _eventSystem.SetSelectedGameObject(gameObject);
        }
    }
}