using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    
    public Transform blaster;
    public GameObject projectile;

    public GameManager gameManager;
    
    void Update()
    {
        // Shoot projectile from blaster while maintaining rotation
        // Only shoot when game is active and space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isGameOver == false) {
            AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
            Instantiate(projectile, blaster.transform.position, projectile.transform.rotation); }
    }
}
