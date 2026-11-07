using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Checks")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    bool isGrounded;

    [Header("Player Settings")]
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpForce = 10f; //o jogo

    Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
         playerRb.velocity = new Vector2(playerSpeed, playerRb.velocity.y); // pega o rigidbody do player e faz ele "andar" para a direita
    }
}
