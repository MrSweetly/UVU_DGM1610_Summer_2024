using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public void increaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void decreaseScore(int amount)
    {
        score -= amount;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
