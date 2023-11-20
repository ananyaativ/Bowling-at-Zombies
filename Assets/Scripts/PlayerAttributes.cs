using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttributes : MonoBehaviour
{
    public static PlayerAttributes instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI healthText;

    int score = 0;
    int highScore = 0;
    int health = 50;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
        healthText.text = "HEALTH: " + health.ToString();
    }

    public void ChangeHealthBy(int change)
    {
        health += change;
        healthText.text = "HEALTH: " + health.ToString();
        if (health <= 0)
        {
            // Write code for displaying end game screen
            Debug.Log("End game");
        }
    }

    public void ChangeScoreBy(int change)
    {
        score += change;
        scoreText.text = "SCORE: " + score.ToString();
        if (highScore < score)
            PlayerPrefs.SetInt("highScore", score);
    }
}
