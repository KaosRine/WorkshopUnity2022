namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class SelectionArrows : MonoBehaviour
    {
        [SerializeField]
        private Image[] _images = null;

        private void Awake()
        {
            SetVisibility(false);
        }

        public void SetVisibility(bool isVisible)
        {
            if (isVisible == true)
            {
                foreach (var image in _images)
                {
                    image.color = new Color(255, 255, 255, 1);
                }
            }
            else
            {
                foreach (var image in _images)
                {
                    image.color = new Color(255, 255, 255, 0);
                }
            }
        }
    }
}