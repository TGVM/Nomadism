using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Events
    public static event EventHandler OnAnyObjectPicked;
    public static event EventHandler OnAnyObjectPut;

    //Constants
    private float INITIAL_SPEED = 5f;
    private float INITIAL_RANGE = 10f;
    private int INITIAL_CAPACITY = 5;
    private int INITIAL_EXTRA_LIFES = 0;

    //Non-Serializable privates
    private Vector3 movePosition;
    private List<GameObject> allObjects;
    private bool canControl = true;
    private bool isWalking = false;

    //Serializable privates
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private int inventory = 0;
    [SerializeField] private int capacity;
    [SerializeField] private int extraLifes;
    [SerializeField] private Transform fence;
    [SerializeField] private Transform spikes;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PlayerParticleSystem _particleSystem;

    private float footstepTimer;
    private float footstepTimerMax = .7f;

    //SaveFile
    private SaveFile saveFile;


    void Start()
    {
        saveFile = SaveManager.Instance.LoadFromJson();
        movePosition = transform.position;
        //allObjects = GameObject.FindGameObjectsWithTag("Collectable").ToList();

        allObjects = ObjectsGenerator.Instance.GetAllObjectsList();

        speed = INITIAL_SPEED + saveFile.upgradesList[0].currentLevel;
        range = INITIAL_RANGE + saveFile.upgradesList[1].currentLevel * 10;
        capacity = INITIAL_CAPACITY + saveFile.upgradesList[2].currentLevel;
        extraLifes = INITIAL_EXTRA_LIFES + saveFile.upgradesList[3].currentLevel;
    }

    void Update()
    {
        if (canControl)
        {
            Movement();
            ObjectAction();
            footstepTimer -= Time.deltaTime;
            if (footstepTimer < 0)
            {
                footstepTimer = footstepTimerMax;

                if (isWalking)
                {
                    SoundManager.Instance.PlayFootstepsSound(transform.position, 1f);

                }
            }
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
        if(transform.position != movePosition)
        {

            _particleSystem.Play();
            isWalking = true;
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
                    SpawnedObject so = target.GetComponent<SpawnedObject>();
                    InventoryManager.Instance.FillInventory(so);
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
                    spawnPos.y = 0;
                    Quaternion spawnRot = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));

                    string trapType = InventoryManager.Instance.decideTrap();
                    
                    if(trapType == "stone")
                    {
                        prefab = Instantiate(spikes, spawnPos, spawnRot);

                    }
                    else if(trapType == "wood")
                    {
                        prefab = Instantiate(fence, spawnPos, spawnRot);

                    }


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

    public void RemoveExtraLife()
    {
        extraLifes -= 1;
    }

    public bool HasExtraLife()
    {
        return extraLifes > 0;
    }
}
