using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Hero.HealthSystem
{
    [RequireComponent(typeof(Image))]
    public class Heart : MonoBehaviour
    {
        [SerializeField] private float _lerpDuration;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.fillAmount = 1;
        }

        public void ToFillInHeart()
        {
            StartCoroutine(SmoothFill(0, 1, _lerpDuration, Fill));
        }
        
        public void ToFillOutHeart()
        {
            StartCoroutine(SmoothFill(1, 0, _lerpDuration, Destroy));
        }

        private IEnumerator SmoothFill(float startValue, float endValue, float duration, Action<float> lerpEnd)
        {
            float elapsed = 0;

            while (elapsed < duration)
            {
                _image.fillAmount = Mathf.Lerp(startValue, endValue, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;

            }
            
            lerpEnd?.Invoke(endValue);
        }

        private void Destroy(float value)
        {
            _image.fillAmount = value;
        }

        private void Fill(float value)
        {
            _image.fillAmount = value;
        }
    }
}
