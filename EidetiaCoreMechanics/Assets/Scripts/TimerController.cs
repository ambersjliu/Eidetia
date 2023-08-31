using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public TMP_Text timeCounter;

    private bool timerGoing;

    public float totalTime;
    public float timeLeft;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        timerGoing = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //timerGoing = false;
    }

    public void beginTimer()
    {
        timerGoing = true;
        timeLeft = totalTime;
        StartCoroutine(UpdateTimer());
    }

    public void endTimer()
    {
        Debug.Log("Stopped timer");
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            timeLeft -= Time.deltaTime;

            float minutes = Mathf.FloorToInt((timeLeft+1) / 60);
            float seconds = Mathf.FloorToInt((timeLeft + 1) % 60);

            if(timeCounter != null)
            {
                timeCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                Debug.Log("Time's up!");
                endTimer();
                GameManager.Instance.UpdateGameState(GameState.lose);
            }

            yield return null;
        }
    }
}
