using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2f;

    [Header("Spawn Area (SpriteRenderer)")]
    [SerializeField] private SpriteRenderer spawnArea;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnArea == null)
        {
            Debug.LogWarning("EnemySpawner: Missing prefab or spawn area.");
            return;
        }

        Vector2 spawnMin = spawnArea.bounds.min;
        Vector2 spawnMax = spawnArea.bounds.max;

        float randomX = Random.Range(spawnMin.x, spawnMax.x);
        float spawnY = spawnMax.y; // Spawna no topo da caixa

        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
