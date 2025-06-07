using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private float enemySpawnInterval = 2f;

    [Header("Obstacle Settings")]
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private float obstacleSpawnInterval = 4f;

    [Header("Special Item Settings")]
    [SerializeField] private GameObject specialItemPrefab;
    [SerializeField] private float minSpecialItemInterval = 10f;
    [SerializeField] private float maxSpecialItemInterval = 20f;

    [Header("Spawn Area (SpriteRenderer)")]
    [SerializeField] private SpriteRenderer spawnArea;

    private float enemyTimer;
    private float obstacleTimer;

    void Start()
    {
        StartCoroutine(SpecialItemSpawnRoutine());
    }

    void Update()
    {
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= enemySpawnInterval)
        {
            SpawnRandomFromList(enemyPrefabs);
            enemyTimer = 0f;
        }

        obstacleTimer += Time.deltaTime;
        if (obstacleTimer >= obstacleSpawnInterval)
        {
            SpawnRandomFromList(obstaclePrefabs);
            obstacleTimer = 0f;
        }
    }

    private void SpawnRandomFromList(List<GameObject> prefabList)
    {
        if (prefabList == null || prefabList.Count == 0 || spawnArea == null) return;

        Vector2 spawnMin = spawnArea.bounds.min;
        Vector2 spawnMax = spawnArea.bounds.max;

        float randomX = Random.Range(spawnMin.x, spawnMax.x);
        float spawnY = spawnMax.y;

        GameObject prefabToSpawn = prefabList[Random.Range(0, prefabList.Count)];
        Instantiate(prefabToSpawn, new Vector3(randomX, spawnY, 0f), Quaternion.identity);
    }

    private IEnumerator SpecialItemSpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpecialItemInterval, maxSpecialItemInterval);
            yield return new WaitForSeconds(waitTime);

            if (specialItemPrefab != null && spawnArea != null)
            {
                Vector2 spawnMin = spawnArea.bounds.min;
                Vector2 spawnMax = spawnArea.bounds.max;

                float randomX = Random.Range(spawnMin.x, spawnMax.x);
                float spawnY = spawnMax.y;

                Instantiate(specialItemPrefab, new Vector3(randomX, spawnY, 0f), Quaternion.identity);
            }
        }
    }
}
