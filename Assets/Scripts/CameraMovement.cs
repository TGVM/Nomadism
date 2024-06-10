using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    public int Speed = 50;
    [SerializeField] private float xMinValue;
    [SerializeField] private float zMinValue;
    [SerializeField] private float xMaxValue;
    [SerializeField] private float zMaxValue;


    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * Speed * -0.5f;
        float zAxisValue = Input.GetAxis("Vertical") * Speed * -0.5f;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);

        Vector3 aux = transform.position;
        if(transform.position.x < xMinValue)
        {
            aux.x = xMinValue;
            transform.position = aux;
        }
        if (transform.position.x > xMaxValue)
        {
            aux.x = xMaxValue;
            transform.position = aux;
        }
        if (transform.position.z < zMinValue)
        {
            aux.z = zMinValue;
            transform.position = aux;
        }
        if (transform.position.z > zMaxValue)
        {
            aux.z = zMaxValue;
            transform.position = aux;
        }

    }
}
