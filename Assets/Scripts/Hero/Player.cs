using Environment;
using Environment.Bullet;
using Hero.HealthSystem;
using Infrastructure;
using Rival;
using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(PlayerCollisionHandler))]
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour
    {
        private PlayerCollisionHandler _handler;
        private Health _health;

        public Health Health => _health;

        private void Awake()
        {
            _handler = GetComponent<PlayerCollisionHandler>();
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _handler.CollisionDetected += ProcessCollision;
        }

        private void OnDisable()
        {
            _handler.CollisionDetected -= ProcessCollision;
        }
        
        private void ProcessCollision(IInteractable interactable)
        {
            switch (interactable)
            {
                case Fireball fireball:
                    interactable.Interact();
                    _health.TakeDamage(fireball.Damage);
                    break;
                case Enemy enemy:
                    interactable.Interact();
                    _health.TakeDamage(enemy.Damage);
                    break;
                case Ground:
                    _health.TakeDamage(_health.CurrentHealth);
                    break;
            }
        }
    }
}
