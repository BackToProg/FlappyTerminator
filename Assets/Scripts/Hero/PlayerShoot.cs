using Environment.Bullet;
using UnityEngine;

namespace Hero
{
    public class PlayerShoot : FireballShoot
    {
        [SerializeField] private FireballSpawner fireballSpawner;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            if (fireballSpawner.TryGetObject(out Fireball fireball))
            {
                SpawnFireball(fireball);
            }
        }
    }
}
