using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance {  get; private set; }

    private float currentRunTimer = 0f;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentRunTimer += Time.deltaTime;
    }


    public float GetCurrentRunTimer()
    {
        return currentRunTimer;
    }

}
