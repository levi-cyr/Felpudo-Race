using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("GameLimit"))
        {
            Destroy(gameObject);
        }

        if (hit.gameObject.CompareTag("Player"))
        {
            //PlayerController playerControllerScript = hit.GetComponent<PlayerController>();
            Destroy(gameObject);
        }
    }
}
