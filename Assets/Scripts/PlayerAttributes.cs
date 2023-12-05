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
    public GameObject gun1;
    public GameObject gun2;
    public GameObject magazine;

    [SerializeField]
    AudioSource zombieAudio;

    int score = 0;
    int highScore = 0;
    int maxHealth = 100;
    int health = 0;

    private void Awake()
    {
        instance = this;
        health = maxHealth;
    }

    // Start is called before the first frame update
    
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
        healthText.text = "HEALTH: " + health.ToString();
        zombieAudio.Play();
    }

    private void Update()
    {
        if (health <= 0)
        { 
            GameOver();
            //stop displaying gun and magazine
            gameOver.SetActive(true);

            dead = true;
            //Debug.Log("End game");
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
        health = maxHealth;
        dead = false;
        gameOver.SetActive(false);
        zombieAudio.Play();
        gun1.SetActive(true);
        gun2.SetActive(true);
        magazine.SetActive(true);
    }


    public void GameOver()
    {

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("zombie");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }

        zombieAudio.Stop();
        gun1.SetActive(false);
        gun2.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("magazine"));

    }


}
