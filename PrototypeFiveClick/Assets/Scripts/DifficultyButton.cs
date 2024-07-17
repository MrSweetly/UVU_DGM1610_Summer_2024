using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    
    private GameManager gameManager;
    
    private Button button;
    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty); }

    // Difficutly
    private void SetDifficulty() {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty); }
}
