using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpForce = 1.5f;
    private Rigidbody2D Rigidbody2D;
    private bool grounded;
    private float horizontal;

    private Vector2 input;
    private Vector3 direction;
    private Animator Animator;

    Vector2 startPos;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        startPos = transform.position;
    }

    private void Update()
    {
        // Movimiento
        horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("running", horizontal != 0.0f);

        if (horizontal < 0.0f) transform.localScale = new Vector3(-2.0f, 2.0f, 2.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

        // Detectar Suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, speed))
        {
            grounded = true;
        }
        else grounded = false;

        // Salto
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(horizontal * speed, Rigidbody2D.linearVelocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = startPos;
    }

}
