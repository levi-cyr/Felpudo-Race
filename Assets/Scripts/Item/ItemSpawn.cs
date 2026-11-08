using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    //prefab do inimigo
    public GameObject itemPrefab;
    //intervalo entre spawns (segundos)
    public float timeBetweenSpawn = 5f;
    public float itemSpeed = 1f;

    void Start()
    {
        //começa a gerar inimigos repetidamente
        InvokeRepeating("ItemSpawner", 0f, timeBetweenSpawn);
    }

    void ItemSpawner()
    {
        Vector2 spawnLocation = transform.position;

        //instancia o inimigo
        GameObject item = Instantiate(itemPrefab, spawnLocation, Quaternion.identity);

        //inicia o movimento automático (corrotina)
        StartCoroutine(MoveItem(item));
    }

    public void CancelItemSpawner() // faz o inimigo parar de spawnar
    {
        CancelInvoke("ItemSpawner");
        StopCoroutine("MoveItem");
    }
    IEnumerator MoveItem(GameObject item)
    {
        while (item != null)
        {
            item.transform.Translate(Vector2.left * itemSpeed * Time.deltaTime);
            yield break; // Sai da corrotina
        }
    }
}
