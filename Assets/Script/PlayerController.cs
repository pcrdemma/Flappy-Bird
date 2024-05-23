using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private Vector3 direction;
    private Vector3 startPosition; // To store the start position
    public float gravity = -9.8f;
    public float strength = 5f;
    private LifeSystem lifeSystem;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeSystem = FindObjectOfType<LifeSystem>(); // Find the LifeSystem component in the scene
        startPosition = transform.position; // Store the initial position
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            AnimateSprite(); // Call animation on input
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        animator.SetTrigger("OnClick");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            lifeSystem.Damage(1); // Decrease life by 1
        }
        else if (other.gameObject.CompareTag("Score"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            ResetPosition(); // Reset position when hitting the ground
        }
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
        direction = Vector3.zero;
    }

}
     