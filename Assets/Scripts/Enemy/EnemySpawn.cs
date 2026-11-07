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
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        while (enemy != null)
        {
            enemy.transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);

            //se o inimigo sair do limite visível, destrói o objeto
            if (enemyScript != null && enemyScript.destroyEnemy)
            {
                Destroy(enemy);
                Debug.Log("oye como va");
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }
}
