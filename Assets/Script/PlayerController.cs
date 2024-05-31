
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private Vector3 direction;
    private Vector3 startPosition;
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
        lifeSystem = FindObjectOfType<LifeSystem>(); 
        startPosition = transform.position; 
    }

    private void OnEnable()
    {
        transform.position = startPosition; 
        direction = Vector3.zero;
        
        var playerControls = inputActions.FindActionMap("Player");
        jumpAction = playerControls.FindAction("Jump");

        jumpAction.performed += ctx => Jump(); 

        jumpAction.Enable(); 
    }

    private void Update()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }


    private void OnDisable()
    {
        jumpAction.Disable(); 
    }

    private void Jump()
    {
        direction = Vector3.up * strength;
        AnimateSprite(); 
    }

    private void AnimateSprite()
    {
        if(animator != null)
        {
            animator.SetTrigger("OnClick");

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            lifeSystem.Damage(1); 
            StartCoroutine(HandleTransparency()); 
        }
        else if (other.gameObject.CompareTag("Score"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit the ground, triggering game over");
            SceneManager.LoadScene("GameOver"); 
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
        float blinkCount = 3.5f; 
        float blinkDuration = 0.1f;
        Color transparentColor = new Color(1f, 1f, 1f, 0.5f);
        Color originalColor = spriteRenderer.color;

        for (int i = 0; i < blinkCount; i++)
        {
            spriteRenderer.color = transparentColor;
            yield return new WaitForSeconds(blinkDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
