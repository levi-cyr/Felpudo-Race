using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] ItemSpawn[] itemSpawnScript;
    [SerializeField] EnemySpawn enemySpawnScript;
    [SerializeField] CameraController cameraScript;

    [Header("Components")]
    [SerializeField] GameObject defeatText;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject playerGameObject;

    public void PlayerDefeat()
    {
        foreach (ItemSpawn spawner in itemSpawnScript) // para cada script "ItemSpawn" ele percorre e vai cancelando. Atualmente tem 2 que preciso fazer isto
        {
            if (spawner != null)
            {
                spawner.CancelItemSpawner();
            }
        }
        cameraScript.cameraSpeed = 0f;
        Destroy(playerGameObject); // destroi o objeto do player
        enemySpawnScript.CancelEnemySpawner(); // cancela o spawn de inimigo
        defeatText.SetActive(true); // ativa o texto de derrota
    }
    public void Win()
    {
        Destroy(playerGameObject); // destroi o objeto do player
        enemySpawnScript.CancelEnemySpawner(); // cancela o spawn de inimigo
        winText.SetActive(true);
    }
}
