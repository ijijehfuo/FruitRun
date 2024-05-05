using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerController : MonoBehaviour
{
    private SpriteLibrary Library;

    public float DeathHeight = -7f;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;

    private bool isGround;
    private bool isSliding = false;
    private int jumpCount = 0;
    public int maxJump = 2;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Library = GetComponent<SpriteLibrary>();
        Library.spriteLibraryAsset = DataManager.Instance.SelectCharacter.Asset;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSlide();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSlide();
        }

        if (!isSliding)
        {
            Move();
            if (Input.GetButtonDown("Jump") && jumpCount < maxJump)
            {
                Jump();
            }
        }

        if (transform.position.y <= DeathHeight)
        {
            GameManager.Instance.GameOver();
        }

        if (GameManager.Instance.IsGameOver)
        {
            Destroy(this.gameObject);
        }

        if (GameManager.Instance.IsPause)
        {
            rb.Sleep();
        }
        else
        {
            rb.WakeUp();
        }
    }

    public void StartSlide()
    {
        isSliding = true;
        audioManager.Instance.PlayEffect(ClipName.Slide);
        animator.SetBool("bSlide", true);
        transform.Rotate(0, 0, 90);
    }

    public void StopSlide()
    {
        isSliding = false;
        animator.SetBool("bSlide", false);
        transform.Rotate(0, 0, -90);
    }

    public void Jump()
    {
        if (!isSliding && jumpCount < maxJump)
        {
            audioManager.Instance.PlayEffect(ClipName.Jump);
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGround = false;
            jumpCount++;
        }
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
                animator.SetTrigger("Hit");
                collision.GetComponent<Obstacles>().OnEarned();
            }
            else if (collision.GetComponent<Items>() != null)
            {
                collision.GetComponent<Items>().OnEarned();
            }
        }
    }
}
