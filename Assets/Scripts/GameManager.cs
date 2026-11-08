using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] ItemSpawn[] itemSpawnScript;
    [SerializeField] EnemySpawn enemySpawnScript;
    [SerializeField] CameraController cameraScript;
    [SerializeField] Timer timerScript;

    [Header("Components")]
    [SerializeField] GameObject continueScreen;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject playerGameObject;

    public bool canContinue = false;

    void Update()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canContinue)
        {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Oye comova");
        }
    }

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
        canContinue = true;
        continueScreen.SetActive(true);
    }
    public void Win()
    {
        Destroy(playerGameObject); // destroi o objeto do player
        enemySpawnScript.CancelEnemySpawner(); // cancela o spawn de inimigo
        winText.SetActive(true);
    }
}
