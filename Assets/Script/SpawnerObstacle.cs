using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{
    public GameObject prefab;
    public float appearance = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    private bool stopSpawning = false;

    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += HandleScoreChanged;  // Subscribe to the event
        InvokeRepeating(nameof(Appearance), appearance, appearance);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= HandleScoreChanged;  // Unsubscribe from the event
        CancelInvoke(nameof(Appearance));
    }

    private void Appearance()
    {
        if (!stopSpawning)
        {
            GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        }
    }

    private void HandleScoreChanged(int newScore)
    {
        if (newScore > 10 && newScore < 15)
        {
            stopSpawning = true;
        }
        else
        {
            stopSpawning = false;
        }
    }
}
