using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float DeathHeight = -7f;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGround;
    private int jumpCount = 0;
    public int maxJump = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && jumpCount < maxJump)
        {
            Jump();
        }
        if (transform.position.y <= DeathHeight)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGround = false;
        jumpCount++;
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            if (collision.GetComponent<Coin>() != null)
            {
                collision.GetComponent<Coin>().OnEarned();
            }
            else if (collision.GetComponent<Obstacles>() != null)
            {
                collision.GetComponent<Obstacles>().OnEarned();
            }
        }
    }
}
