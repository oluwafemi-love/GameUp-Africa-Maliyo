using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60; 
    bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    private GameManagerX gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out! Gameover!");
                timeRemaining = 0;
                timerIsRunning = false;
                gameManager.GameOver();
            }
        }
    }


   public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}", seconds);
    }

    
}
