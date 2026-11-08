using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Checks")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    public bool isGrounded;

    [Header("Player Settings")]
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpForce = 10f; //o jogo

    Rigidbody2D playerRb;
    Animator playerAnim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // checa se o player esta encostando no chao

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // se estiver no chao e pressionar o espaço ele adiciona uma força de impulso para cima no player poder pular
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAnim.SetBool("Jump", true);
        }
        else
        {
            playerAnim.SetBool("Jump", false);
        }
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(playerSpeed, playerRb.velocity.y); // pega o rigidbody do player e faz ele "andar" para a direita
    }

    void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = new Color(0f, 1f, 0f); // Green with custom alpha
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        }
        else
        {
            Gizmos.color = new Color(1f, 0f, 0f); // Red with custom alpha
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        }
    }
}
