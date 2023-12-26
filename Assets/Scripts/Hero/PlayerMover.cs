using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _tapForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;
        [SerializeField] private float _maxHeight;
        
        private Rigidbody2D _rigidbody2D;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < _maxHeight)
            {
                _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
                transform.rotation = _maxRotation;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
