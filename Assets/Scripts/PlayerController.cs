using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool active = true;
    public float speed = 4.0f;
    public float jumpForce = 1.5f;
    public float jumpCooldown = 0.2f;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private Collider2D collider;

    private bool grounded;
    private float horizontal;
    private bool isJumping;

    private Vector2 input;
    private Vector3 direction;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Movimiento
        horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("running", horizontal != 0.0f);
        Animator.SetBool("jumping", transform.position.y != 0.0f);

        if (horizontal < 0.0f) transform.localScale = new Vector3(-2.0f, 2.0f, 2.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

        // Detectar Suelo
        grounded = Physics2D.Raycast(transform.position, Vector3.down, speed);
        if (transform.position.y <= 0.0f) { isJumping = false; };

        // Salto
        if (Input.GetKey(KeyCode.Space) && grounded && !isJumping)
        {
            Jump();
            isJumping = true;
        }

        // Muerte & Reinicio del juego
        if (!active)
        {
            return;
        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(horizontal * speed, Rigidbody2D.linearVelocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(new Vector2(Rigidbody2D.linearVelocity.x, jumpForce));
    }

    private void MiniJump()
    {
        Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, jumpForce / 2);
    }

    private void Die()
    {
        active = false;
        collider.enabled = false;
        MiniJump();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

}
