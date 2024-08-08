using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public ScoreManager scoreManager;

    public int scoreToGive;

    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.increaseScore(scoreToGive);
        Destroy(gameObject); // Destory connected object
        Destroy(other.gameObject); // Destory colliding object
    }
}
