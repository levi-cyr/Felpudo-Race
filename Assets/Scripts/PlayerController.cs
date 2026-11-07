using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] float playerSpeed = 5f;

    void Start()
    {

    }
    void Update()
    {
        gameObject.transform.Translate(Vector2.right * playerSpeed * Time.deltaTime); // pega o transform do player e faz ele "andar" para a direita
    }
}
