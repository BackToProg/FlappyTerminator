using System;
using System.Collections;
using Environment.Bullet;
using UnityEngine;

namespace Rival
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyShoot : FireballShoot
    {
        [SerializeField] private int _shootDelay;

        private bool _isActive;
        private Enemy _enemy;
        private Coroutine _coroutine;

        private void Awake()
        {
            _isActive = true;
            _enemy = GetComponent<Enemy>();
        }

        private void Start()
        {
            _coroutine = StartCoroutine(Shoot());
        }
        
        private IEnumerator Shoot()
        {
            WaitForSeconds shootDelay = new WaitForSeconds(_shootDelay);

            while (_isActive)
            {
                if (_enemy.FireballSpawner.TryGetObject(out Fireball fireball))
                {
                    SpawnFireball(fireball);
                }

                yield return shootDelay;
            }
        }
    }
}
