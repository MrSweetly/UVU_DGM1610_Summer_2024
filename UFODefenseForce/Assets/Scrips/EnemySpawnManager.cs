using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
   public GameObject[] ufoPrefabs;

   private float spawnRangeX = 8f;
   private float spawnPosZ = 20f;

   private float startDelay = 2f;
   private float spawnInterval = 1.5f;
   

   void Start()
   {
      InvokeRepeating("SpawnRandomUfo", startDelay, spawnInterval);
   }

   void SpawnRandomUfo()
   {
      Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
      int ufoIndex = Random.Range(0, ufoPrefabs.Length);
      Instantiate(ufoPrefabs[ufoIndex], spawnPos, ufoPrefabs[ufoIndex].transform.rotation);
   }
}
