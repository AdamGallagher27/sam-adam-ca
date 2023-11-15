using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{

    // https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/

    public float currentTime;
    public bool timerIsActive;
    private string timeText;


    void displayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        Debug.Log(timeText);
    }

    void Start()
    {
        timerIsActive = true;        
    }

    void Update()
    {
        if(timerIsActive)
        {
            if(currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                displayTime(currentTime);
            }
            else
            {
                Debug.Log("Time is up");
                currentTime = 0;
                timerIsActive = false;
            }
        }        
    }
}
