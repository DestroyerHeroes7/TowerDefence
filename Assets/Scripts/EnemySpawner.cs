using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;

    public float spawnPointOffset = 0.8f;
    void Start()
    {
        SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawnPoint.position + (transform.right.normalized * Random.Range(-spawnPointOffset, spawnPointOffset)), enemySpawnPoint.rotation);
    }
}
