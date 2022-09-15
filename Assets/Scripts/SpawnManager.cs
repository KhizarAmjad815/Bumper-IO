using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-2, spawnRange);
        return new Vector3(spawnPosX, 0f, spawnPosZ);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            Instantiate(enemyPrefabs[i], GenerateSpawnPosition(), enemyPrefabs[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
