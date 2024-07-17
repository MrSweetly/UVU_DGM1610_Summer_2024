using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionPart;
    
    private GameManager gameManager;
    
    private Rigidbody targetRb;

    public int pointValue;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    
    void Start() {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); }

    // Object upward movment
    private Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed); }

    // Object torque
    private float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque); }

    //Object spawn position
    private Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); }

    // When click
    private void OnMouseDown() {
        if (gameManager.isGameActive) {
            Destroy(gameObject);
            Instantiate(explosionPart, transform.position, explosionPart.transform.rotation);
            gameManager.UpdateScore(pointValue); }
    }

    // When miss point objects hit
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")) {
            gameManager.GameOver(); }
    }
}
