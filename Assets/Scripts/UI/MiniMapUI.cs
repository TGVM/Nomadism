using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapUI : MonoBehaviour
{
    [SerializeField] MinimapCameraManager minimap;

    // Start is called before the first frame update
    void Update()
    {
        if(minimap.IsActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }


    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }


}
