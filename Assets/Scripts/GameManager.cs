using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    public SunSpawner sunSpawner; // Reference to the SunSpawner class

    private int score;
    private int lives = 3;
    public bool isGameActive;

    void Start()
    {
        scoreText.gameObject.SetActive(false);
        livesText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }




    public void StartGame(float difficulty)
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);
        sunSpawner.spawnInterval = difficulty;
        UpdateLivesText();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText();
        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Life: " + lives;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        livesText.gameObject.SetActive(false);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
