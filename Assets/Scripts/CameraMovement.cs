using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    public int Speed = 50;

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * Speed * -1;
        float zAxisValue = Input.GetAxis("Vertical") * Speed * -1;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);
    }
}
