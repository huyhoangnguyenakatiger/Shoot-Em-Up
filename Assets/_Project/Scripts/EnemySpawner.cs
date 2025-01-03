using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shmup
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        float spawnTimer;
        int enemiesSpawned;

        // void OnValidate() {
        //     splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        // }

        // void Start() => enemyFactory = new EnemyFactory();

        void Start()
        {
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
            enemyFactory = new EnemyFactory();
        }

        void Update()
        {
            spawnTimer += Time.deltaTime;

            if (enemiesSpawned < maxEnemies && spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        void SpawnEnemy()
        {
            if (enemyTypes.Count == 0 || splines.Count == 0)
            {
                return;
            }
            EnemyType enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[Random.Range(0, splines.Count)];

            enemyFactory.CreateEnemy(enemyType, spline);
            enemiesSpawned++;
        }
    }
}