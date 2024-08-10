using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    
    public ScoreManager scoreManager;

    public int scoreToGive;

    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
        scoreManager.increaseScore(scoreToGive);
        Destroy(gameObject); // Destory connected object
        Destroy(other.gameObject); // Destory colliding object
    }
}
