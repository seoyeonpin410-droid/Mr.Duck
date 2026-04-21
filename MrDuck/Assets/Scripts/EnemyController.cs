using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // 추가
    private bool isMovingRight = true;
    private float timer; // 랜덤 이동 추가
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // 추가
        timer = Random.Range(1f, 3f); // 랜덤 이동 추가(시간 설정)
    }

    private void Update()
    {spriteRenderer = GetComponent<SpriteRenderer>(); // 추가
        //방향 바꿈 
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            isMovingRight = !isMovingRight;
            timer = Random.Range(1f, 4f); 
        }

        if (isMovingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            transform.localScale = new Vector3(-1, 1, 1); 
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            transform.localScale = new Vector3(1, 1, 1); 
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
            timer = Random.Range(1f, 4f); // 벽에 부딪히면 리셋
        }
    }
}