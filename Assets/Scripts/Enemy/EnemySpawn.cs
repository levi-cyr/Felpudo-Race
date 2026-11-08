using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //prefab do inimigo
    public GameObject enemyPrefab;
    //intervalo entre spawns (segundos)
    public float timeBetweenSpawn = 3f;
    public float enemySpeed = 3f;

    void Start()
    {
        //começa a gerar inimigos repetidamente
        InvokeRepeating("EnemySpawner", 0f, timeBetweenSpawn);
    }

    void EnemySpawner()
    {
        Vector2 spawnLocation = transform.position;

        //instancia o inimigo
        GameObject enemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);

        //inicia o movimento automático (corrotina)
        StartCoroutine(MoveEnemy(enemy));
    }

    public void CancelEnemySpawner() // faz o inimigo parar de spawnar
    {
        CancelInvoke("EnemySpawner");
        StopCoroutine("MoveEnemy");
    }
    IEnumerator MoveEnemy(GameObject enemy)
    {
        while (enemy != null)
        {
            enemy.transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
            yield break; // Sai da corrotina
        }
    }
}
