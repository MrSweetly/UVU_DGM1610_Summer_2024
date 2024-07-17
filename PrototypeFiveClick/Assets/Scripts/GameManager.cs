using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject scoreCounter;
    public List<GameObject> targets;
    public bool isGameActive;

    public Button restartButton;

    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private float spawnRate = 1.0f;
    
    // Start of game
    public void StartGame(int difficulty) {
        titleScreen.gameObject.SetActive(false);
        scoreCounter.gameObject.SetActive(true);
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0); }
    
    // Spawn targets
    IEnumerator SpawnTarget()
    {
        while (isGameActive) {
            
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]); }
    }

    // Update score
    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; }
    
    // When game is over 
    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true); }
    
    // When game restarts
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}
