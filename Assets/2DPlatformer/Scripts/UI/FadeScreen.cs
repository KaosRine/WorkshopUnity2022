namespace GSGD2.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using GSGD2.Utilities;

    public class FadeScreen : MonoBehaviour
    {
        [SerializeField]
        private Image _image = null;

        [SerializeField]
        private float _fadeSpeed = 1f;

        [SerializeField]
        private float _fadeTime = 1f;

        private Timer _fadeInTimer = new Timer();
        private Timer _fadeOutTimer = new Timer();

        public void FadeIn()
        {
            _fadeInTimer.Start(_fadeTime);
        }

        public void FadeOut()
        {
            _fadeOutTimer.Start(_fadeTime);
        }

        private void OnEnable()
        {
            _fadeInTimer.StateChanged -= FadeInTimerOnStateChanged;
            _fadeInTimer.StateChanged += FadeInTimerOnStateChanged;
        }

        private void OnDisable()
        {
            _fadeInTimer.StateChanged -= FadeInTimerOnStateChanged;
        }

        private void Update()
        {
            if (_fadeInTimer.IsRunning == true)
            {
                _fadeInTimer.Update();
                _image.color = new Color(0, 0, 0, 0 + (_fadeSpeed * Time.deltaTime));
                Debug.Log(_image.color.a);
            }

            if (_fadeOutTimer.IsRunning == true)
            {
                _fadeOutTimer.Update();
                _image.color = new Color(0, 0, 0, 1 - (_fadeSpeed * Time.deltaTime));
            }
        }

        private void FadeInTimerOnStateChanged(Timer timer, Timer.State state)
        {
            if (state == Timer.State.Finished)
            {
                FadeOut();
            }
        }
    }
}