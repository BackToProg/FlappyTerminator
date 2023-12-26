using UnityEngine;

namespace Rival
{
   public class EnemyPoolContainer : MonoBehaviour
   {
      [SerializeField] private int _capacity;

      public int Capacity => _capacity;
   }
}
