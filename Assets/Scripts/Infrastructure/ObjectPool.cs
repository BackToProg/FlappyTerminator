using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure
{
    public class ObjectPool : MonoBehaviour
    {
        private List<Component> _objectsInPool = new List<Component>();
        
        protected void Init<T1,T2>(T1[] objectPrefabs, int containerCapacity, T2 container) 
            where T1 : Component
            where T2 : Component
        {
            for (int i = 0; i < containerCapacity; i++)
            {
                int index = Random.Range(0, objectPrefabs.Length);
                T1 newObject = Instantiate(objectPrefabs[index], container.transform);
                newObject.gameObject.SetActive(false);

                _objectsInPool.Add(newObject);
            }
        }
        
        public bool TryGetObject<T>(out T poolObject) where T : Component
        {
            poolObject = (T)_objectsInPool.FirstOrDefault(p => p.gameObject.activeSelf == false);

            return poolObject != null;
        }
    }
}