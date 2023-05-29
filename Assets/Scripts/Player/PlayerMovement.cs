using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed, jumpForce;

    private Rigidbody2D rb;
    private RaycastHit2D[] HitBuffer = new RaycastHit2D[1];

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool isGrounded = CheckGround();
        Vector3 vel = rb.velocity;

        vel.x = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && isGrounded)
            vel.y = jumpForce;
        rb.velocity = vel;

        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("XSpeed", Mathf.Abs(vel.x));
        animator.SetFloat("YVel", vel.y);

        spriteRenderer.flipX = vel.x != 0 ? vel.x < 0 : spriteRenderer.flipX;
    }


    private bool CheckGround()
    {
        return rb.Cast(Vector2.down, HitBuffer, 0.1f) > 0;
    }
}
