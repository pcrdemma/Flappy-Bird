
using UnityEngine;

public class PipesObstacle : MonoBehaviour
{
    public float speed = 5f;
    private float endScreen;

    private void Start()
    {
        endScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }


    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < endScreen)
        {
            Destroy(gameObject);
        }
    }

}
