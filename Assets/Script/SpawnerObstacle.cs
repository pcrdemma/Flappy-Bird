using System.Collections;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject fireSpawnerPrefab;
    public float appearance = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    private bool stopSpawningPipes = false;
    private int pipesSpawned = 0;

    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        InvokeRepeating(nameof(Appearance), appearance, appearance);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        CancelInvoke(nameof(Appearance));
    }

    private void Appearance()
    {
        if (!stopSpawningPipes)
        {
            GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
            pipesSpawned++;

            if (pipesSpawned >= 10)
            {
                stopSpawningPipes = true;
                Instantiate(fireSpawnerPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    private void HandleScoreChanged(int newScore)
    {
        // Handle score change if needed
    }
}
