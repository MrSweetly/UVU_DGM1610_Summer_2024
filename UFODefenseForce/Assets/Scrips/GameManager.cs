using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    private GameObject gameOverText;

    void Awake()
    {
        Time.timeScale = 1; // Normal time
        isGameOver = false;
    }
    
    void Start()
    {
        gameOverText = GameObject.Find("Game Over Text (TMP)");
    }
    
    void Update()
    {
        if (isGameOver) {
            EndGame(); }
        else {
            gameOverText.gameObject.SetActive(false); }
    }

    public void EndGame()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0; // Freeze time
    }
}
