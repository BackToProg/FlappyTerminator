using UnityEngine;

namespace Environment
{
    public class DeactivateZone : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            other.gameObject.SetActive(false);
        }
    }
}
