using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerController : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private EnemyController enemy;
    
    private const float xRange = 5;
    private const float zRange = 3;
    private float startDelay = 2;
    private float spawnInterval = 2;
    private int enemyCount;
    private bool canSpawn = true; // Flag to control spawning

    void Start()
    {
        StartCoroutine(SpawnCoroutine()); // Start coroutine for delayed spawning
    }
    
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(startDelay); // Wait for initial delay

        while (true)
        {
            enemyCount = FindObjectsOfType<EnemyController>().Length;
            if (enemyCount < 5 && canSpawn)
            {
                Spawn();
                canSpawn = false; // Disable spawning until delay finishes
                yield return new WaitForSeconds(spawnInterval); // Wait for spawn interval after enemy is destroyed
                canSpawn = true; // Enable spawning again
            }
            yield return null; // Wait for next frame
        }
    }
    
    private void Spawn()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0, Random.Range(-zRange, zRange));
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex],
            spawnPos,
            enemyPrefabs[enemyIndex].transform.rotation);
    }


}
