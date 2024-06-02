using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 newPosition;
    [SerializeField] float speed = 5f;


    void Start()
    {
        newPosition = transform.position;

        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                newPosition.y = transform.position.y;

                
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

    }
}
