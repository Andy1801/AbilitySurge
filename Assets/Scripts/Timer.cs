using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float timer;
    private float duration;
    private bool timerStarted;

    public Timer(float timer)
    {
        this.timer = timer;
        this.duration = timer;
        this.timerStarted = false;
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public bool getTimerStatus()
    {
        bool timerDone = timer <= 0;

        if (!timerDone && timerStarted)
            timer -= Time.deltaTime;
        else
            StopTimer();

        return timerDone;
    }

    private void StopTimer()
    {
        timerStarted = false;
        timer = duration;
    }


}
