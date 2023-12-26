using UnityEngine;
using Infrastructure;

namespace Environment.Bullet
{
    public class FireballSpawner : ObjectPool
    {
        [SerializeField] private Fireball[] _fireballs;
        [SerializeField] private FireballPoolContainer _container;


        private void Start()
        {
            Init(_fireballs, _container.Capacity, _container);
        }
    }
}
