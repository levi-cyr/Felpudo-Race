using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int playerScore;

    [Header("Text Mesh Pro")]
    public TMP_Text scoreText;
    public GameObject winText;

    GameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
    }
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
       
        if (playerScore >= 5000)
        {
            gameManagerScript.Win();
        }
    }
}
