using System.Collections.Generic;
using UnityEngine;

namespace Hero.HealthSystem
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Heart _heartTemplate;

        private List<Heart> _hearts = new List<Heart>();

        private void OnEnable()
        {
            _player.Health.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _player.Health.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int value)
        {
            if (_hearts.Count < value)
            {
                int healthToCreate = value - _hearts.Count;
                
                for (int i = 0; i < healthToCreate; i++)
                {
                    CreateHeart();
                }
            }
            else if(_hearts.Count > value)
            {
                int healthToDelete = _hearts.Count - value;
                
                for (int i = 0; i < healthToDelete; i++)
                {
                    DestroyHeart(_hearts[_hearts.Count - 1]);
                }
            }
        }

        private void DestroyHeart(Heart heart)
        {
            _hearts.Remove(heart);
            heart.ToFillOutHeart();
        }

        private void CreateHeart()
        {
            Heart newHeart = Instantiate(_heartTemplate, transform);
            _hearts.Add(newHeart);
            newHeart.ToFillInHeart();
        }
    }
}