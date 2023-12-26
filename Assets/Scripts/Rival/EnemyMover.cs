using UnityEngine;

namespace Rival
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private void Update()
        {
            transform.Translate(Vector3.right * (_moveSpeed * Time.deltaTime));
        }
    }
}
