using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool destroyEnemy = false;

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("GameLimit"))
        {
            destroyEnemy = true; // ativa uma chave que permite destruir o inimigo
            Debug.Log("Destruiu inimigo");
        }
        
        if(hit.gameObject.CompareTag("Player"))
        {
            PlayerController playerControllerScript = hit.GetComponent<PlayerController>();
            Destroy(gameObject);
            playerControllerScript.GetHit(1); // tira 1 de dano de coração do player
        }
    }
}
