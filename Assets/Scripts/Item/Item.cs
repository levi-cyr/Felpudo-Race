using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("GameLimit"))
        {
            Destroy(gameObject); // destroi o item quando colide no limite do mapa
        }

        if (hit.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // destroi o item quando colide com o player
        }
    }
}
