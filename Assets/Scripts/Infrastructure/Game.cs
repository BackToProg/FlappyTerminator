using Hero;
using Hero.HealthSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
   public class Game : MonoBehaviour
   {
      [SerializeField] private GameOverScreen _gameOverScreen;
      [SerializeField] private Player _player;
      [SerializeField] private HealthBar _healthBar;


      private void OnEnable()
      {
         _player.Health.OnDie += PlayerDied;
         _gameOverScreen.StartButtonClicked += StartNewGame;
      }

      private void OnDisable()
      {
         _player.Health.OnDie -= PlayerDied;
         _gameOverScreen.StartButtonClicked -= StartNewGame;
      }

      private void StartNewGame()
      {
         Time.timeScale = 1;
         SceneManager.LoadScene(0);
      }

      private void PlayerDied()
      {
         _healthBar.gameObject.SetActive(false);
         _gameOverScreen.Show();
      }
   }
}
