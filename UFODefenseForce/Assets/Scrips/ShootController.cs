using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Transform blaster;
    public GameObject projectile;
    void Update()
    {
        // Shoot projectile from blaster while maintaining rotation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, blaster.transform.position, projectile.transform.rotation);
        }
    }
}
