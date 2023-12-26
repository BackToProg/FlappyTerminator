using Infrastructure;
using Rival;
using UnityEngine;

namespace Environment.Bullet
{
    public class Fireball : MonoBehaviour, IInteractable
    {
        [SerializeField] private int _damage = 1;

        public int Damage => _damage;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Enemy enemy)) return;
            
            gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);
        }
        
        public void Interact()
        { 
            gameObject.SetActive(false);
        }
    }
}
