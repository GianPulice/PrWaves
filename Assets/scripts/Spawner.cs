using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; 
    public Vector2 spawnArea; 

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    private float nextSpawnTime;


    void Start()
    {
        
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomPrefab();

            
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnRandomPrefab()
    {
        
        Vector3 spawnPosition = new Vector3(
            Random.Range(transform.position.x - spawnArea.x / 2f, transform.position.x + spawnArea.x / 2f),
            Random.Range(transform.position.y - spawnArea.y / 2f, transform.position.y + spawnArea.y / 2f),
            transform.position.z
        );

       
        GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

        
        Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
    }
}
