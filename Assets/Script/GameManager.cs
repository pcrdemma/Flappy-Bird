using System;
using UnityEngine;

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
            
            //DontDestroyOnLoad(canva);
            //DontDestroyOnLoad(player);
        }
        else
        {
            //Destroy(gameObject);
            return;
        }

        Application.targetFrameRate = 60;
        NotifyGameSceneStart.onLevelStart += Play;
    }

    public void Play()
    {
        player = FindObjectOfType<PlayerController>();
        canva = FindObjectOfType<CanvaController>();
        /*canva = Instantiate(canvaPrefab);
        player = Instantiate(playerPrefab).GetComponent<PlayerController>();*/
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
        Debug.Log("IncreaseScore");
        score++;
        playerData.score = score;
        canva.UpdateScore(playerData.score);
        OnScoreChanged?.Invoke(score);
    }

}
