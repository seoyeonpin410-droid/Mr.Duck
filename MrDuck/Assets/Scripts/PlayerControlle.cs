using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isTouchingWall;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private Animator pAni;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (pAni != null)
        {
            pAni.SetBool("Walk", moveInput != 0);
            pAni.SetBool("isGrounded", isGrounded);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("Jump");
            pAni.SetBool("Walk", moveInput != 0);
        }
        else if (isTouchingWall)
        {
            rb.linearVelocity = new Vector2(-transform.localScale.x * moveSpeed, jumpForce);
            pAni.SetTrigger("Jump");
            isTouchingWall = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.CompareTag("Finish")) 
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }
        else if (collision.CompareTag("dodo"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, true);
        }
        else if (collision.CompareTag("Wall"))
        {
            isTouchingWall = true;
        }
        else if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
        }
    }


}