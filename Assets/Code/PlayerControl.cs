using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    
    Animator anim;
    private Vector2 lastMoveDirection;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }

        Movement();
        Animate();

        if(Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Machadada");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Especial");
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", true);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("Crouch", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
            anim.SetTrigger("Dash");
        }
    }


    public void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0 ) && (rb.linearVelocity.x != 0 || rb.linearVelocity.y !=0))
        {
            lastMoveDirection = rb.linearVelocity;
        }

        speedX = moveX * movSpeed;
        speedY = moveY * movSpeed;

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speedX, speedY);

    }

    private IEnumerator Dash()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        isDashing = true;

        rb.linearVelocity = new Vector2(moveX * dashSpeed, moveY * dashSpeed);
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

    }


    void Animate()
    {
        anim.SetFloat("MoveX", rb.linearVelocity.x);
        anim.SetFloat("MoveY", rb.linearVelocity.y);
        anim.SetFloat("MoveMagnitude", rb.linearVelocity.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }
}
