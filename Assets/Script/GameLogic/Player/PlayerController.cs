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

    // WHY? 스케일업 아이템을 먹어서
    // HOW? 커지다가 몇초동안 커진상태로 있다가 작아진다
    // (scaleUpSpeed) 빠르게 커지다가
    public float ScaleUpStart = 0.5f;
    public float ScaleUpRemain = 3f;
    public float ScaleUpEnd = 0.5f;
    // {ScaleUPStart}동안 커지다가 {ScaleUpRemain} 커진상태로 있다가 {SclaeUPEnd}만큼 얼마만큼 작아진디
    private Vector3 originScale; // 플레이어의 원래크기
    public float ScaleUpFactor = 2f; // 스케일업 배울
    private Coroutine scaleUpCo;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Library = GetComponent<SpriteLibrary>();
        Library.spriteLibraryAsset = DataManager.Instance.SelectCharacter.Asset;
        originScale = transform.localScale;
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
        if (GameManager.Instance.IsScaleEventActive)
        {
            GameManager.Instance.IsScaleEventActive = false;
            ScaleUpEvent();
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

    public IEnumerator StartScaleChange()
    {
        Vector3 targetScale = ScaleUpFactor * originScale;
        float currentTime = 0f;

        while (currentTime >= ScaleUpStart)
        {
            transform.localScale = Vector3.Lerp(originScale, targetScale, currentTime / ScaleUpStart);
            currentTime += Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        transform.localScale = targetScale;

        // 유지시간
        yield return new WaitForSeconds(ScaleUpRemain);

        currentTime = 0f;
        while (currentTime < ScaleUpEnd)
        {
            transform.localScale = Vector3.Lerp(targetScale, originScale, currentTime / ScaleUpStart);
            currentTime += Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
        transform.localScale = originScale;
        scaleUpCo = null;
    }

    public void ScaleUpEvent()
    {
        if (scaleUpCo != null)
        {
            StopCoroutine(StartScaleChange());
        }
        StartCoroutine(StartScaleChange());
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
                if (scaleUpCo == null)
                { 
                    animator.SetTrigger("Hit");
                    collision.GetComponent<Obstacles>().OnEarned();
                }
            }
            else if (collision.GetComponent<Items>() != null)
            {
                collision.GetComponent<Items>().OnEarned();
            }
        }
    }
}
