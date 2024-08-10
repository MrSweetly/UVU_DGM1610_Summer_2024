using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private ParticleSystem boom;
    
    public ScoreManager scoreManager;

    public int scoreToGive;

    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
        ProcessBoom();
        scoreManager.increaseScore(scoreToGive);
        Destroy(gameObject); // Destory connected object
        Destroy(other.gameObject); // Destory colliding object
    }

    private void ProcessBoom()
    {
        ParticleSystem flash = Instantiate(boom, transform.position, transform.rotation);
        flash.Play();
    }
}
