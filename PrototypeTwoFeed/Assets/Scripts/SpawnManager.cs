using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnIntensity = 1.5f;
    void Start()
    {
        // Repeat responding random spawn
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnIntensity);
    }

    void SpawnRandomAnimal()
    {
        // Randomly generate animal index and spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, this.animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
            animalPrefabs[animalIndex].transform.rotation);
    }
}
