using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerController player;
    [SerializeField] private Text scoreText;

    private int score;
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
            Destroy(gameObject);
            return; // Add return to prevent further execution
        }

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

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
        score++;
        scoreText.text = score.ToString();
    }
}
