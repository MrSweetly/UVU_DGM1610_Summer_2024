using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject items;

    private float spawnLimitXLeft = -4;
    private float spawnLimitXRight = 4;
    private float spawnPosY = 0.5f;
    
    void Start()
    {
        SpawnItems();
    }

    // Spawn item at random x position at top of play area
    void SpawnItems ()
    {
        // Generate item and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 6);
        
        // instantiate iteml at random spawn location
        Instantiate(items, spawnPos, items.transform.rotation);
        Invoke("SpawnItems", Random.Range(2f,4f));
    }

}
