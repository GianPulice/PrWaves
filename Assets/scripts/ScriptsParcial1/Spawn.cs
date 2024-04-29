using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Vector2 spawnArea;
    public float spawnInterval = 1f;

    private Stack<GameObject> prefabStack;
    private float nextSpawnTime;

    public int spawnCount;

    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;


    void Start()
    {
        prefabStack = new Stack<GameObject>();
        nextSpawnTime = Time.time + spawnInterval;

        
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject prefab = GetRandomPrefab(); 
            prefabStack.Push(prefab); 
        }
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && prefabStack.Count > 0)
        {
            
            GameObject prefabToSpawn = prefabStack.Pop();
            SpawnPrefab(prefabToSpawn);

            
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnPrefab(GameObject prefab)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(transform.position.x - spawnArea.x / 2f, transform.position.x + spawnArea.x / 2f),
            Random.Range(transform.position.y - spawnArea.y / 2f, transform.position.y + spawnArea.y / 2f),
            transform.position.z
        );

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    GameObject GetRandomPrefab()
    {
        
        GameObject[] availablePrefabs = new GameObject[] { enemy, enemy1, enemy2 };

        
        int randomIndex = Random.Range(0, availablePrefabs.Length);

       
        return availablePrefabs[randomIndex];
    }
}
