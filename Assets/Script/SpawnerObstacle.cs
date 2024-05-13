using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject prefab;

    public float appearance = 1f;

    public float minHeight = -1f;

    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Appearance), appearance, appearance);    
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Appearance));
    }

    private void Appearance()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
}
