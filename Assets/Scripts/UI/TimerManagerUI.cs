using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerText;

    
    // Update is called once per frame
    void Update()
    {
        VisualUpdate();
    }

    private void VisualUpdate()
    {
        TimerText.text = ((int)TimerManager.Instance.GetCurrentRunTimer()).ToString() + " s";
    }
}
