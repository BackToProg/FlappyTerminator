using UnityEngine;

namespace Environment.Bullet
{
    public class FireballShoot : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPosition;

        protected void SpawnFireball(Fireball fireball)
        {
            fireball.transform.position = _bulletSpawnPosition.position;
            fireball.transform.rotation = _bulletSpawnPosition.rotation;
            fireball.gameObject.SetActive(true);
        }
    }
}