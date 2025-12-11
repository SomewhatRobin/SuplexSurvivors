using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerII : MonoBehaviour
{
    public GameObject[] enemyPrefab;   // Enemy prefab
    public Transform[] spawnPoint;     // Places where enemies can spawn
    public float spawnInterval = 2f; // Intervals inbetween spawns
    public int totalEnemies = 50;    // Number of enemies generated 
    public bool knightDiff;
    public float knightChance = 0f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        knightDiff = false;
        knightChance = 0f;
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            if (!knightDiff) //not spawning knights
            {
                if (i % 5 == 0) //Every 5 spawns...
                {
                    Instantiate(enemyPrefab[0], spawnPoint[0].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[1].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[2].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[3].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[4].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[5].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Debug.Log($"It's a Monster House! at {Time.time} seconds."); //Spawn enemies at *EVERY* spawn location

                }

                else
                {
                    Instantiate(enemyPrefab[0], spawnPoint[i % 6].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Debug.Log($"Enemy #{i + 1} Spawned in {Time.time} seconds @ Spawn point #{(i % 6) + 1}");
                }
            }

            else if (knightDiff && knightChance < 1f) //spawning knights
            {
                if (i < 10)
                {
                  //  Debug.LogWarning("Unlucky");
                    knightChance -= 0.5f;
                }
                else if (i < 30)
                {
                  //  Debug.LogWarning("Mild Unlucky");
                    knightChance -= 0.2f;
                }
                else if (i < 50)
                {
                  //  Debug.LogWarning("Eh");
                    knightChance -= 0.1f;
                }
                else if (i < 90)
                {
                   // Debug.LogWarning("Oops! all knights.");
                    knightChance += 0.05f;
                }
                else
                {
                   // Debug.Log("HAHAHAHA");
                }

                if (i % 5 == 0) //Every 5 spawns...
                {
                    //Half of these are knight spawns, monster house proc on knight spawn is bad enough.
                    Instantiate(enemyPrefab[1], spawnPoint[0].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[1].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[1], spawnPoint[2].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[3].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[0], spawnPoint[4].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[1], spawnPoint[5].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Debug.Log($"It's a Monster House! at {Time.time} seconds."); //Spawn enemies at *EVERY* spawn location

                }

                else
                {
                    Instantiate(enemyPrefab[1], spawnPoint[i % 6].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Debug.Log($"Enemy #{i + 1} Spawned in {Time.time} seconds @ Spawn point #{(i % 6) + 1}");
                }
            }

            else
            {
                if (i % 5 == 0) //Every 5 spawns...
                {
                    //All of these are knight spawns, you've gone far enough
                    Instantiate(enemyPrefab[1], spawnPoint[0].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[1], spawnPoint[1].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[1], spawnPoint[2].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[1], spawnPoint[3].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[1], spawnPoint[4].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Instantiate(enemyPrefab[1], spawnPoint[5].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Debug.Log($"It's a Monster House! at {Time.time} seconds."); //Spawn enemies at *EVERY* spawn location

                }

                else
                {
                    Instantiate(enemyPrefab[1], spawnPoint[i % 6].position, Quaternion.Euler(-45.0f, 0f, 0f));
                    Debug.Log($"Enemy #{i + 1} Spawned in {Time.time} seconds @ Spawn point #{(i % 6) + 1}");
                }
            }

                knightChance += 0.05f; //Add a 5% chance for knights to spawn
            if (Random.value < knightChance)
            {
                knightDiff = true;
            }
            else
            { 
                knightDiff = false; 
            }

                //Both of these count for 1 spawn, so the total enemies int is gonna be lower than the actual total enemies spawned in the scene
                yield return new WaitForSeconds(spawnInterval);

        }
    }
}
