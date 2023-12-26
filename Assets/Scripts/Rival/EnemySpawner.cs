using System.Collections;
using Environment.Bullet;
using Infrastructure;
using UnityEngine;

namespace Rival
{
    public class EnemySpawner : ObjectPool
    {
        [SerializeField] private Enemy[] _enemyPrefabs;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _spawnSpeed;
        [SerializeField] private EnemyPoolContainer _container;
        [SerializeField] private FireballSpawner _fireballSpawner;

        private void Start()
        {
            Init(_enemyPrefabs, _container.Capacity, _container);
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            WaitForSeconds waitForSpawn = new WaitForSeconds(_spawnSpeed);

            while (TryGetObject(out Enemy enemy))
            {
                SetEnemy(enemy);
                yield return waitForSpawn;
            }
        }

        private void SetEnemy(Enemy enemy)
        {
            int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
            Vector3 spawnPointPosition = _spawnPoints[randomSpawnPointIndex].transform.position;

            enemy.gameObject.SetActive(true);
            enemy.Init(_fireballSpawner);
            enemy.gameObject.transform.position = spawnPointPosition;
        }
    }
}
