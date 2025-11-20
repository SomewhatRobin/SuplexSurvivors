using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Enemy prefab
    public Transform spawnPoint;     // Place where enemies will spawn
    public float spawnInterval = 2f; // Intervals inbetween spawns
    public int totalEnemies = 10;    // Number of enemies generated 

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"Enemy #{i + 1} Spawned in {Time.time} seconds");
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}