using System;
using Infrastructure;
using UnityEngine;

namespace Hero
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
       public event Action<IInteractable> CollisionDetected;

        private void OnValidate()
        {
          GetComponent<CircleCollider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                CollisionDetected?.Invoke(interactable);
            }
        }
    }
}
