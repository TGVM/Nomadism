using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    public static ObjectsGenerator Instance { get; private set; }

    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject stonePrefab;

    [SerializeField] private float minx;
    [SerializeField] private float minz;
    [SerializeField] private float maxx;
    [SerializeField] private float maxz;

    [SerializeField] private int numberOfObjects;

    private List<GameObject> allObjects;

    private SaveFile saveFile;


    private void Awake()
    {
        saveFile = SaveManager.Instance.LoadFromJson();
        allObjects = new List<GameObject>();
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadMap();   
    }

    private void LoadMap()
    {
        float chanceOfSpawningStone = saveFile.upgradesList[5].GetCurrentLevel() * 0.1f;
        GameObject objectToSpawn = null;
        for(int i = 0; i < numberOfObjects; i++)
        {
            

            Vector3 spawnPos = Vector3.zero;
            float randx = Random.Range(minx, maxx);
            float randz = Random.Range(minz, maxz);

            while((randx>-3 && randx<3) && (randz > -3 && randz < 3))
            {
                randx = Random.Range(minx, maxx);
                randz = Random.Range(minz, maxz);
            }

            spawnPos.x = randx;
            spawnPos.y = 1;
            spawnPos.z = randz;

            if (chanceOfSpawningStone > Random.Range(0f, 1f))
            {
                objectToSpawn = stonePrefab;
                spawnPos.y -= 1;
            }
            else
            {
                objectToSpawn = treePrefab;
            }

            allObjects.Add(Instantiate(objectToSpawn, spawnPos, Quaternion.identity));

        }
    }


    public List<GameObject> GetAllObjectsList()
    {
        return allObjects;
    }

}
