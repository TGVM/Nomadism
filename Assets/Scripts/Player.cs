using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movePosition;
    private List<GameObject> allObjects;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float range = 2f;
    [SerializeField] private int inventory = 0;
    [SerializeField] private int capacity = 5;
    

    void Start()
    {
        movePosition = transform.position;
        allObjects = GameObject.FindGameObjectsWithTag("Collectable").ToList();
        
    }

    void Update()
    {
        Movement();
        CollectObject();
    }


    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                movePosition = hit.point;
                movePosition.y = transform.position.y;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, movePosition, speed * Time.deltaTime);

    }

    void CollectObject()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GetNearestObjectDistance() < range)
            {
                if (inventory < capacity)
                {
                    GameObject target = GetNearestObject();
                    target.SetActive(false);
                    allObjects.Remove(target);

                    inventory++;
                }

            }
        }
    }

    GameObject GetNearestObject()
    {
        GameObject nearestObject = null;
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < allObjects.Count; i++)
        {
            float distance = (allObjects[i].transform.position - transform.position).sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestObject = allObjects[i];
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }

    float GetNearestObjectDistance()
    {
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < allObjects.Count; i++)
        {
            float distance = (allObjects[i].transform.position - transform.position).sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
            }
        }

        return nearestDistance;
    }


}
