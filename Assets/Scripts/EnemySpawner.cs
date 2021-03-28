using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;

    public float spawnPointOffset = 0.8f;
    public float minSpawnRate;
    public float maxSpawnRate;
    void Start()
    {
        StartCoroutine(EnemySpawnLoop());
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawnPoint.position + (transform.right.normalized * Random.Range(-spawnPointOffset, spawnPointOffset)), enemySpawnPoint.rotation);
    }
    private IEnumerator EnemySpawnLoop()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
        }
    }
}
