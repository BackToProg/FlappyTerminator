using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
   [RequireComponent(typeof(CanvasGroup))]
   public class GameOverScreen : MonoBehaviour
   {
      [SerializeField] private Button _startButton;

      private CanvasGroup _canvasGroup;

      public event Action StartButtonClicked; 

      private void OnEnable()
      {
         _startButton.onClick.AddListener(OnStartButtonClick);
      }

      private void Awake()
      {
         _canvasGroup = GetComponent<CanvasGroup>();
      }

      private void OnDisable()
      {
         _startButton.onClick.RemoveListener(OnStartButtonClick);
      }
      
      private void OnStartButtonClick()
      {
         StartButtonClicked?.Invoke();

      }

      public void Show()
      {
         _canvasGroup.alpha = 1;
         Time.timeScale = 0;
      }

   }
}
