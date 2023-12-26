using System.Collections;
using TMPro;
using UnityEngine;

namespace Environment
{
   public class Score : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI _scoreText;
      [SerializeField] private int _scorePointPerSecond = 1;

      private void Start()
      {
         StartCoroutine(ChangeScore());
      }

      private IEnumerator ChangeScore()
      {
         WaitForSeconds waitForSeconds = new WaitForSeconds(_scorePointPerSecond);
         int score = 0;

         while (true)
         {
            score++;
            _scoreText.text = $"Score: {score}";

            yield return waitForSeconds;

         }

      }
   }
}
