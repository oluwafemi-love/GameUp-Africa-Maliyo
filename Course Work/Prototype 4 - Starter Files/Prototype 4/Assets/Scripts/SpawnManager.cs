using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameObject powerupPrefab;
    public GameObject Player;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int waveNumber = 1;

    private void Start()
    {
        
        SpawnEnemyWave(waveNumber);
        GeneratePowerup();

    }

    private void Update()
    {
        //We want to know how many enemy are on the Island, if they are all dead or they have not arrived, then spawn them.
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0 && Player.transform.position.y > -10.0f) //&& Player.transform.position.y > -10.0f I USED THESE LINE TO STOP THE SPAWNING WHEN THE PLAYER IS DEAD.
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            GeneratePowerup();
        }
         
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(spawnPrefab, GenerateSpawnPosition(), spawnPrefab.transform.rotation);
        }
    }

    void GeneratePowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
}
