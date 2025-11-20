using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab del enemigo
    public Transform spawnPoint;     // Lugar donde aparecen
    public float spawnInterval = 2f; // Cada cuántos segundos spawnea
    public int totalEnemies = 10;    // Cuántos enemigos generar

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log($"Enemigo #{i + 1} spawneado en {Time.time} segundos");
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}