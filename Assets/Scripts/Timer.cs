using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 9f;
    public bool stopTime;
    public GameObject continueObject;
    GameManager gameManagerScript;
    void Start()
    {
        gameManagerScript = GetComponent<GameManager>();
        stopTime = false;
    }

    void Update()
    {
        if (continueObject.activeSelf)
        {
            if (stopTime == false)
            {
                timeLeft = timeLeft - Time.deltaTime;
                timer.text = "Continue? " + timeLeft.ToString("F0");
            }

        }

        if (timeLeft <= 0)
        {
            stopTime = true;
            gameManagerScript.canContinue = false;
            timeLeft = 0;
        }
    }
}
