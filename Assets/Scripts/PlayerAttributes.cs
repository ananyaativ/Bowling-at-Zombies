using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttributes : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    int highScore = 0;
    int health = 50;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();

    }

    public void ChangeHealthBy(int dec)
    {
        health +=dec;
        Debug.Log("Health: " + health);
    }

    public void ChangeScoreBy(int inc)
    {
        score += inc;
        //Debug.Log("Score: " + score);
    }
}
