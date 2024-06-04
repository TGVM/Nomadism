using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static event EventHandler OnAnyObjectPicked;
    public static event EventHandler OnAnyObjectPut;


    private Vector3 movePosition;
    private List<GameObject> allObjects;
    private bool canControl = true;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float range = 10f;
    [SerializeField] private int inventory = 0;
    [SerializeField] private int capacity = 5;
    [SerializeField] private Transform fence;
    [SerializeField] private Transform spawnPoint;




    void Start()
    {
        movePosition = transform.position;
        allObjects = GameObject.FindGameObjectsWithTag("Collectable").ToList();
        
    }

    void Update()
    {
        if (canControl)
        {
            Movement();
            ObjectAction();
        }
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
        Vector3 targetDirection = movePosition - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 2 * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, movePosition, speed * Time.deltaTime);

    }

    void ObjectAction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GetNearestObjectDistance() <= range)
            {
                if (inventory < capacity)
                {
                    GameObject target = GetNearestObject();
                    target.SetActive(false);
                    allObjects.Remove(target);

                    inventory++;

                    OnAnyObjectPicked?.Invoke(this, EventArgs.Empty);
                }

            }
            else
            {
                if (inventory > 0)
                {
                    Transform prefab;
                    Vector3 spawnPos = spawnPoint.transform.position;
                    Quaternion spawnRot = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
                    //spawnRot = spawnRot * (0, 90, 0);
                    prefab = Instantiate(fence, spawnPos, spawnRot );
                    //prefab.rotation = spawnRot;

                    inventory--;

                    OnAnyObjectPut?.Invoke(this, EventArgs.Empty);
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

    public void BlockControl()
    {
        canControl = false;
    }

    public int GetCurrentItems()
    {
        return inventory;
    }

    public int GetMaxItems()
    {
        return capacity;
    }
}
