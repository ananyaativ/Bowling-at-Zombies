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
    public GameObject gameOver;
    public bool dead = false;

    int score = 0;
    int highScore = 0;
    int health = 2;

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

    private void Update()
    {
        if (health <= 0)
        {
            // Write code for displaying end game screen
            gameOver.SetActive(true);
            dead = true;
            Debug.Log("End game");
        }
        if (dead && OVRInput.Get(OVRInput.Button.One))
        {
            RestartGame();
        }
    }

    public void ChangeHealthBy(int change)
    {
        health += change;
        healthText.text = "HEALTH: " + health.ToString();
    }

    public void ChangeScoreBy(int change)
    {
        score += change;
        scoreText.text = "SCORE: " + score.ToString();
        if (highScore < score)
            PlayerPrefs.SetInt("highScore", score);
    }

    public void RestartGame()
    {
        score = 0;
        health = 5;
        dead = false;
        gameOver.SetActive(false);
    }
}
