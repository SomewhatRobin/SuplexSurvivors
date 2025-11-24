using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerII : MonoBehaviour
{
    public GameObject enemyPrefab;   // Enemy prefab
    public Transform[] spawnPoint;     // Places where enemies can spawn
    public float spawnInterval = 2f; // Intervals inbetween spawns
    public int totalEnemies = 50;    // Number of enemies generated 

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            if ( i % 5 == 0) //Every 5 spawns...
            {
                Instantiate(enemyPrefab, spawnPoint[0].position, Quaternion.identity);
                Instantiate(enemyPrefab, spawnPoint[1].position, Quaternion.identity);
                Instantiate(enemyPrefab, spawnPoint[2].position, Quaternion.identity);
                Instantiate(enemyPrefab, spawnPoint[3].position, Quaternion.identity);
                Instantiate(enemyPrefab, spawnPoint[4].position, Quaternion.identity);
                Instantiate(enemyPrefab, spawnPoint[5].position, Quaternion.identity);
                Debug.Log($"It's a Monster House! at {Time.time} seconds."); //Spawn enemies at *EVERY* spawn location

            }

            else
            {
                Instantiate(enemyPrefab, spawnPoint[i % 6].position, Quaternion.identity);
                Debug.Log($"Enemy #{i + 1} Spawned in {Time.time} seconds @ Spawn point #{(i % 6) + 1}");
            }

            //Both of these count for 1 spawn, so the total enemies int is gonna be lower than the actual total enemies spawned in the scene
            yield return new WaitForSeconds(spawnInterval);

        }
    }
}
