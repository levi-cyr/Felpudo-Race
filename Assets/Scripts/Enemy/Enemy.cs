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
    }
}
