using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsticalPrefab;
    private PlayerController playerControllerScript;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObsticle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObsticle()
    {
        // Spawn Obsticle while playing
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obsticalPrefab, spawnPos, obsticalPrefab.transform.rotation);   
        }
    }
}
