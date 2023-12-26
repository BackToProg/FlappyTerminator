using System;
using UnityEngine;

namespace Hero.HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 5;

        private int _currentHealth;

        public event Action<int> OnHealthChanged;
        public event Action OnDie; 

        public int CurrentHealth => _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Math.Max(0, _currentHealth - damage);

            if (_currentHealth == 0)
                Die();

            OnHealthChanged?.Invoke(_currentHealth);
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
        
    }
}