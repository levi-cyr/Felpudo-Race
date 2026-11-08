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
    [SerializeField] float horizontalSpeed = 3f;
    [SerializeField] float jumpForce = 10f; //o jogo
    public int currentLife = 3;
    public GameObject[] heartIcons;

    [Header("Scripts")]
    [SerializeField] Score scoreScript;
    [SerializeField] ItemSpawn[] itemSpawnScript;
    [SerializeField] EnemySpawn enemySpawnScript;
    [SerializeField] CameraController cameraScript;
    
    [Header("Components")]
    [SerializeField] GameObject defeatText;
    Rigidbody2D playerRb;
    Animator playerAnim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    void Update()
    {
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    #region Player movement
    void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * horizontalSpeed;
        playerRb.velocity = new Vector2(playerSpeed + horizontalMovement, playerRb.velocity.y); // pega o rigidbody do player e faz ele "andar" para a direita
    }

    void PlayerJump()
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
    #endregion

    #region Player life
    public void GetHit(int damage)
    {
        currentLife = currentLife - damage;
        UpdateHeartUI();
        if (currentLife <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        foreach (ItemSpawn spawner in itemSpawnScript) // para cada script "ItemSpawn" ele percorre e vai cancelando. Atualmente tem 2 que preciso fazer isto
        {
            if (spawner != null)
            {
                spawner.CancelItemSpawner();
            }
        }
        cameraScript.cameraSpeed = 0f;
        Destroy(gameObject); // destroi o objeto do player
        enemySpawnScript.CancelEnemySpawner(); // cancela o spawn de inimigo
        defeatText.SetActive(true); // ativa o texto de derrota
    }

    void UpdateHeartUI()
    {
        for (int i = 0; i < heartIcons.Length; i++) // loopa a quantidade de gameobject do coração que tem na cena para poder atualizar
        {
            heartIcons[i].SetActive(i < currentLife); // se o valor que o loop esta (i) for maior que a vida atual, 
            // ele desativa esse valor e se for menor ele ativa. Caso a vida atual for igual ao valor do loop, ele tambem desativa
        }
    }
    #endregion

    void OnTriggerEnter2D(Collider2D hit)
    {
        switch (hit.tag)
        {
            case "Banana PickUp":
                scoreScript.playerScore = scoreScript.playerScore + 100;
                Debug.Log("Coletou banana");
                break;
            case "Watermelon PickUp":
                scoreScript.playerScore = scoreScript.playerScore + 300;
                Debug.Log("Coletou melancia");
                break;
        }
    }

    #region Debug
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
    #endregion
}
