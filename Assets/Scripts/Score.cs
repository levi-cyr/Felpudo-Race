using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }
}
