using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FireObstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject firePrefab;

    public int numberOfFire = 5;
    private int fireSpawned = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;

        Invoke(nameof(SpawnFire), 1.5f); // Appelle la m�thode SpawnFire toutes les 1.5 secondes

    }

    public void SpawnFire()
    {
        if (fireSpawned < numberOfFire)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(0, 10), 0f, 0f);
            Instantiate(firePrefab, spawnPosition, Quaternion.identity);
            fireSpawned++;
        }
        else
        {
            CancelInvoke(nameof(SpawnFire)); // Arr�te le spawning lorsque le nombre maximum de boules de feu est atteint
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            BounceOnGround();
        }
    }

    private void BounceOnGround()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(-5, Random.Range(5, 15));
        }
        else
        {
            Debug.LogWarning("Rigidbody2D non r�f�renc� dans FireObstacle.");
        }
    }

    private void Update()
    {
        // V�rifie si la Time.timeScale est � 0
        if (GameObject.Find("GameManager").GetComponent<GameManager>().score >= 15)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("WinMenu");
        }
     
        
    }
}
