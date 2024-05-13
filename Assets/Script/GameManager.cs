using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;

    public Text scoreText; 

    public GameObject playButton;

    public GameObject gameOverText;

    private int score;

    private void Awake()
    {

        Application.targetFrameRate = 60;
        Pause();
        
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOverText.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        PipesObstacle[] pipes = FindObjectsOfType<PipesObstacle>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }


    public void GameOver()
    {
        gameOverText.SetActive(true);
        playButton.SetActive(true);

        Pause();
        
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
