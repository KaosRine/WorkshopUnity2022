namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using TMPro;

    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private EventSystem _eventSystem = null;

        [SerializeField]
        private SelectionArrows[] _selectionArrows = null;

        private void Update()
        {
            var currentButton = _eventSystem.currentSelectedGameObject;
            var currentSelectionArrows = currentButton.GetComponentInChildren<SelectionArrows>();
            currentSelectionArrows.SetVisibility(true);

            foreach (var arrows in _selectionArrows)
            {
                if (arrows != currentSelectionArrows)
                {
                    arrows.SetVisibility(false);
                }
            }
        }
    }
}