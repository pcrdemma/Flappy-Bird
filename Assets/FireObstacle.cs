using UnityEngine;

public class FireObstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject firePrefab;
    public int numberOfFire = 5;
    private int fireSpawned = 0;
    public float spawnInterval = 3f;

    private void Start()
    {
        // Spawn fire at position y = 0 after a delay
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f; // Assurez-vous que la gravité est activée
        InvokeRepeating(nameof(SpawnFire), 1f, spawnInterval);

    }

    private void SpawnFire()
    {
        if (fireSpawned < numberOfFire)
        {
            // Définir la position de spawn aléatoire
            Vector3 spawnPosition = new Vector3(Random.Range(0, 10), 0f, 0f);

            // Instancier le prefab de la balle de feu à la position de spawn
            Instantiate(firePrefab, spawnPosition, Quaternion.identity);
            fireSpawned++;
        }
        else
        {
            CancelInvoke(nameof(SpawnFire)); // Arrête le spawning lorsque le nombre de balles de feu est atteint
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Fire hit the ground");
            BounceOnGround();
        }
    }

    private void BounceOnGround()
    {
        Debug.Log("Bouncing on the ground");
        // Vérifiez si rb est non nul avant d'accéder à ses propriétés
        if (rb != null)
        {
            // Inverser la vitesse verticale pour simuler le rebond
            rb.velocity = new Vector2(-5, Random.Range(5, 15));
        }
        else
        {
            Debug.LogWarning("Rigidbody2D non référencé dans FireObstacle.");
        }
    }

}
