using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private Image timerImage;


    private void Update()
    {
        timerImage.fillAmount = GetPlayingTimerNormalized();
    }


    private float GetPlayingTimerNormalized()
    {
        return (TimerManager.Instance.GetCurrentRunTimer() / 720);
    }
}