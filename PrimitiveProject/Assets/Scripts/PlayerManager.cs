using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instace;

    private void Awake() {
        instace = this; }
    
    public GameObject player;
}
