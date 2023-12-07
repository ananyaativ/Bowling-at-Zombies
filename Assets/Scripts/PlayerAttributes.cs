using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public static PlayerAttributes instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOver;
    public GameObject scoreCanvas;
    public bool dead = false;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject magazine;
    public GameObject restartButton;
    public Zombie zombie;

    [SerializeField]
    GameObject gotHitScreen;

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
        healthText.text = "HEALTH: " + health.ToString();
        zombieAudio.Play();
    }

    private void Update()
    {
        if (gotHitScreen != null)
        {
            if (gotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = gotHitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                gotHitScreen.GetComponent<Image>().color = color;
            }
        }
        if (health <= 0)
        { 
            GameOver();
            //stop displaying gun and magazine
            gameOver.SetActive(true);

            //Debug.Log("End game");
        }
    }

    public void ChangeHealthBy(int change)
    {
        health += change;
        healthText.text = "HEALTH: " + health.ToString();
        Debug.Log("Health: " + health);
        if (health % 5 == 0)
        {
            var color = gotHitScreen.GetComponent<Image>().color;
            color.a = 1.0f;
            gotHitScreen.GetComponent<Image>().color = color;
        }
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
        if (dead)
        {
            // Resetting score and health
            score = 0;
            health = maxHealth;
            scoreText.text = "SCORE: " + score.ToString();
            healthText.text = "HEALTH: " + health.ToString();

            dead = false;
            gameOver.SetActive(false);
            zombieAudio.Play();

            // Resetting guns
            gun1.SetActive(true);
            gun1.GetComponent<VRShoot>().rounds = 12;
            gun2.SetActive(true);
            gun2.GetComponent<VRShoot>().rounds = 12;

            magazine.GetComponent<Magazine>().SpawnMagazine();
            magazine.SetActive(true);
            restartButton.SetActive(false);
            scoreCanvas.SetActive(true);
            zombie.SpawnZombie();
        }
    }


    public void GameOver()
    {
        dead = true;

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("zombie");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }
        scoreCanvas.SetActive(false);
        zombieAudio.Stop();
        gun1.SetActive(false);
        gun2.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("magazine"));
        restartButton.SetActive(true);

        gameOverText.text = "Score: " + score + "\nHigh Score: " + highScore;
    }

    public int GetScore()
    {
        return score;
    }
}
