
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private Vector3 direction;
    private Vector3 startPosition; // To store the start position
    public float gravity = -9.8f;
    public float strength = 5f;
    private LifeSystem lifeSystem;
    private Rigidbody2D rb;
    private bool isGrounded;
    public InputActionAsset inputActions;
    private InputAction jumpAction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeSystem = FindObjectOfType<LifeSystem>(); // Find the LifeSystem component in the scene
        startPosition = transform.position; // Store the initial position
    }

    private void OnEnable()
    {
        transform.position = startPosition; // Ensure the player starts at the start position
        direction = Vector3.zero;
        
        var playerControls = inputActions.FindActionMap("Player");
        jumpAction = playerControls.FindAction("Jump");

        jumpAction.performed += ctx => Jump(); // Call Jump() when the jump action is performed

        jumpAction.Enable(); // Enable the input actions
    }

    private void Update()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }


    private void OnDisable()
    {
        jumpAction.Disable(); // Disable the input actions
    }

    private void Jump()
    {
        direction = Vector3.up * strength;
        AnimateSprite(); // Call animation on input
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
            StartCoroutine(HandleTransparency()); // Start the transparency coroutine
        }
        else if (other.gameObject.CompareTag("Score"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit the ground, triggering game over");
            SceneManager.LoadScene("GameOver"); // End the game immediately
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator HandleTransparency()
    {
        float blinkCount = 3.5f; // Number of times to blink
        float blinkDuration = 0.1f; // Duration of each blink
        Color transparentColor = new Color(1f, 1f, 1f, 0.5f); // Transparent color
        Color originalColor = spriteRenderer.color; // Original color of the sprite

        for (int i = 0; i < blinkCount; i++)
        {
            // Make the sprite transparent
            spriteRenderer.color = transparentColor;

            // Wait for a short duration
            yield return new WaitForSeconds(blinkDuration);

            // Revert the sprite to its original color
            spriteRenderer.color = originalColor;

            // Wait for another short duration
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
