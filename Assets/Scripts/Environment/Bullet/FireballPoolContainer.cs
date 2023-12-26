using UnityEngine;

namespace Environment.Bullet
{
    public class FireballPoolContainer : MonoBehaviour
    {
        [SerializeField] private int _capacity;

        public int Capacity => _capacity;
    }
}
