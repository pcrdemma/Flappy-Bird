using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // faire les prefab a instancier
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private PlayerController player;

    [SerializeField] private CanvaController canvaPrefab;
    CanvaController canva;

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
            return;
        }

        Application.targetFrameRate = 60;
        NotifyGameSceneStart.onLevelStart += Play;
    }


    public void Play()
    {
        canva = Instantiate(canvaPrefab);
        player = Instantiate(playerPrefab).GetComponent<PlayerController>();
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
        score++;
        canva.UpdateScore(score);
    }
}
