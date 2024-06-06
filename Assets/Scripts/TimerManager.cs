using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance {  get; private set; }

    private float currentRunTimer = 0f;

    private bool running = true;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(running) currentRunTimer += Time.deltaTime;
    }


    public float GetCurrentRunTimer()
    {
        return currentRunTimer;
    }

    public void StopRun()
    {
        running = false;
    }

    public bool IsRunning()
    {
        return running;
    }

    public void ResetClock()
    {
        currentRunTimer = 0f;
    }

}
