using System;
using UnityEngine;
using System.Collections;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> OnScoreChanged;

    [SerializeField] private PlayerController player;
    [SerializeField] private CanvaController canva;

    public PlayerData playerData;

    public int score;
    public int Score => score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            /*Destroy(gameObject);*/
            return;
        }

        Application.targetFrameRate = 60;
        NotifyGameSceneStart.onLevelStart += Play;
    }

    public void AddScore(int amount)
    {
        if (score < 15 || score > 20)
        {
            score += amount;
            playerData.score = score;
            canva.UpdateScore(playerData.score);
            OnScoreChanged?.Invoke(score);
        }

        if (score == 15)
        {
            StartCoroutine(StopGameWithDelay(2f));
        }
    }

    private IEnumerator StopGameWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StopGame();
    }

    private void StopGame()
    {
         // This will pause the game
        Debug.Log("Game stopped because score is 15.");
        // Additional logic to show game over screen or menu can be added here
    }

    public void Play()
    {
        player = FindObjectOfType<PlayerController>();
        canva = FindObjectOfType<CanvaController>();
        score = 0;

        canva.UpdateScore(score);

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

    public void IncreaseScore()
    {
        AddScore(1);
    }
}
