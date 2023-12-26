using Environment.Bullet;
using Infrastructure;
using UnityEngine;

namespace Rival
{
    [RequireComponent(typeof(EnemyMover))]
    public class Enemy : MonoBehaviour, IInteractable
    {
        [SerializeField] private int _damage = 2;
        
        private FireballSpawner _fireballSpawner;

        public FireballSpawner FireballSpawner => _fireballSpawner;
        public int Damage => _damage;
        
        public void Init(FireballSpawner fireballSpawner)
        {
            _fireballSpawner = fireballSpawner;
        }
        
        public void Interact()
        {
            gameObject.SetActive(false);
        }
    }
}
