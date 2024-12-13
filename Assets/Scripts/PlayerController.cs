using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool active = true;
    public float speed = 4.0f;
    public float jumpForce = 1.5f;
    public int maxJumps = 2; // Número máximo de saltos consecutivos
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private Collider2D collider;
    private bool grounded;
    private float horizontal;
    private bool isJumping;
    private Vector2 input;
    private Vector3 direction;
    private bool[] jumpHistory; // Historial de saltos
    private int jumpCount; // Contador de saltos consecutivos
    private float lastGroundedTime; // Tiempo de última colisión con el suelo

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        jumpHistory = new bool[maxJumps];
        jumpCount = 15;
    }

    private void Update()
    {
        // Movimiento
        horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("running", horizontal != 0.0f);
        Animator.SetBool("jumping", jumpCount > 0);

        if (horizontal < 0.0f) transform.localScale = new Vector3(-2.0f, 2.0f, 2.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

        // Detectar Suelo
        grounded = Physics2D.Raycast(transform.position, Vector3.down, speed);
        // if (grounded)
        // {
        //     jumpCount = 0; // Reiniciar contador al estar en el suelo
        //     lastGroundedTime = Time.time;
        // }

        // Salto condicional
        if (Input.GetKey(KeyCode.Space))
        // if (Input.GetKeyDown(KeyCode.Space))
        {
            if (/*grounded ||*/ jumpCount < maxJumps)
            {
                Jump();
                jumpHistory[jumpCount % maxJumps] = true;
                jumpCount++;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            jumpCount = 0; // Reiniciar contador al estar en el suelo
            lastGroundedTime = Time.time;
            jumpHistory[jumpCount % maxJumps] = false; // Resetear historia de saltos
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(new Vector2(Rigidbody2D.linearVelocity.x, jumpForce));
    }

    private void Die()
    {
        active = false;
        collider.enabled = false;
    }
}
