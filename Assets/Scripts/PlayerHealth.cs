using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool isDead;
    public GameObject deadUI;
    public ScoreController scoreController;
    public Text highscoreText;
    public Text healthText;

    public float timer = 60;
    public Text timerUI;

    public AudioSource audioSource;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        print(PlayerPrefs.GetInt("HighScore"));
        isDead = false;
        deadUI.SetActive(false);
        Time.timeScale = 1;
        scoreController = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerDecreases();

        if (health <= 0)
        {
            isDead = true;
        }

        healthText.text = health.ToString();

        if (isDead || timer <= 0)
        {
            audioSource.PlayOneShot(gameOverSound);
            deadUI.SetActive(true);
            if (scoreController.score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", scoreController.score);
                highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }

    void TimerDecreases()
    {
        if (timer <= 0) { return; }
        timer -= Time.deltaTime;
        timerUI.text = Mathf.CeilToInt(timer).ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
}
